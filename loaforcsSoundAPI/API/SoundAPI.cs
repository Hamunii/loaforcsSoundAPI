﻿using loaforcsSoundAPI.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace loaforcsSoundAPI.API {
    public static class SoundAPI {
        internal static Dictionary<string, AudioFormatProvider> FileFormats = new Dictionary<string, AudioFormatProvider>();
        internal static Dictionary<string, ConditionProvider> ConditionProviders = new Dictionary<string, ConditionProvider>();

        internal static ConcurrentDictionary<string, List<SoundReplacementCollection>> SoundReplacements = new ConcurrentDictionary<string, List<SoundReplacementCollection>>();


        public static void RegisterAudioFormatProvider(string extension, AudioFormatProvider provider) {
            FileFormats.Add(extension, provider);
        }

        public static void RegisterConditionProvider(string extension, ConditionProvider provider) {
            ConditionProviders.Add(extension, provider);
        }

        public static string FormatMatchString(string input) {
            if (input.Split(":").Length == 2) {
                input = "*:" + input;
            }
            return input;
        }

        public static bool MatchStrings(string[] a, string b) {
            string[] expected = b.Split(":");
            if (expected[0] != "*" && expected[0] != a[0]) return false; // parent gameobject mismatch
            if (expected[1] != "*" && expected[1] != a[1]) return false; // gameobject mismatch
            return a[2] == expected[2];
        }
    }
}
