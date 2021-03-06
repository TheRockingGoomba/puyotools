﻿using System;
using System.Collections.Generic;
using System.IO;

using PuyoTools.Modules;
using PuyoTools.Modules.Archive;

using PuyoTools.GUI;

namespace PuyoTools
{
    public static class Archive
    {
        // Archive format dictionary
        public static Dictionary<ArchiveFormat, ArchiveBase> Formats;

        // Initalize the archive format dictionary
        public static void Initalize()
        {
            Formats = new Dictionary<ArchiveFormat, ArchiveBase>();

            Formats.Add(ArchiveFormat.Acx, new AcxArchive());
            Formats.Add(ArchiveFormat.Afs, new AfsArchive());
            Formats.Add(ArchiveFormat.Gnt, new GntArchive());
            Formats.Add(ArchiveFormat.Gvm, new GvmArchive());
            Formats.Add(ArchiveFormat.Mrg, new MrgArchive());
            Formats.Add(ArchiveFormat.Narc, new NarcArchive());
            Formats.Add(ArchiveFormat.OneUnleashed, new OneUnleashedArchive());
            Formats.Add(ArchiveFormat.Pvm, new PvmArchive());
            Formats.Add(ArchiveFormat.Snt, new SntArchive());
            Formats.Add(ArchiveFormat.Spk, new SpkArchive());
            Formats.Add(ArchiveFormat.Tex, new TexArchive());
            Formats.Add(ArchiveFormat.U8,  new U8Archive());
        }

        // Opens an archive with the specified archive format.
        public static ArchiveReader Open(Stream source, ArchiveFormat format)
        {
            return Formats[format].Open(source);
        }

        // Creates an archive with the specified archive format and writer settings.
        public static ArchiveWriter Create(Stream source, ArchiveFormat format)
        {
            return Formats[format].Create(source);
        }

        // Returns the archive format used by the source archive.
        public static ArchiveFormat GetFormat(Stream source, string fname)
        {
            foreach (KeyValuePair<ArchiveFormat, ArchiveBase> format in Formats)
            {
                if (format.Value.Is(source, fname))
                    return format.Key;
            }

            return ArchiveFormat.Unknown;
        }

        // Returns the module for this archive format.
        public static ArchiveBase GetModule(ArchiveFormat format)
        {
            return Formats[format];
        }
    }

    // List of archive formats
    public enum ArchiveFormat
    {
        Unknown,
        Acx,
        Afs,
        Gnt,
        Gvm,
        Mrg,
        Narc,
        OneUnleashed,
        Pvm,
        Snt,
        Spk,
        Tex,
        U8,
        Plugin,
    }
}