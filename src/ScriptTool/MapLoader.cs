﻿using System;
using System.Collections.Generic;
using System.Text;
using Blamite.Blam;
using Blamite.Blam.Scripting;
using Blamite.Serialization;
using Blamite.Serialization.Settings;
using System.Linq;
using Blamite.IO;
using System.IO;

namespace ScriptTool
{
    public static class MapLoader
    {
        public static IEnumerable<ICacheFile> LoadAllMaps(string[] paths, EngineDatabase db)
        {
            List<ICacheFile> result = new List<ICacheFile>();
            foreach(string path in paths)
            {
                using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                var reader = new EndianReader(stream, Endian.BigEndian);
                var cache = CacheFileLoader.LoadCacheFile(reader, Path.GetFileNameWithoutExtension(path), db);
                result.Add(cache);
            }
            return result;
        }


        public static Dictionary<string, ScriptTable> LoadAllScriptFiles(string path, EngineDatabase db, out EngineDescription engineInfo)
        {
            Dictionary<string, ScriptTable> result = new Dictionary<string, ScriptTable>();
            string fileName = Path.GetFileNameWithoutExtension(path);
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var reader = new EndianReader(stream, Endian.BigEndian);
                var cache = CacheFileLoader.LoadCacheFile(reader,fileName, db, out engineInfo);
                if (cache.Type != CacheFileType.Shared && cache.Type != CacheFileType.SinglePlayerShared && cache.ScriptFiles.Length > 0)
                {
                    foreach(var file in cache.ScriptFiles)
                    {
                        result.Add(file.Name, file.LoadScripts(reader));
                    }
                }
            }
            return result;
        }

    }
}