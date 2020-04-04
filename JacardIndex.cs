using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Plataformas
{
    public class JacardIndex
    {
        private const int DEFAULT_K = 3;

        /// <summary>
        /// Return k, the length of k-shingles (aka n-grams).
        /// </summary>
        protected int k { get; }

        /// <summary>
        /// Pattern for finding multiple following spaces
        /// </summary>
        private static readonly Regex SPACE_REG = new Regex("\\s+");

        public JacardIndex(int k)
        {
            if (k <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(k), "k should be positive!");
            }

            this.k = k;
        }
        protected IDictionary<string, int> GetProfile(string s)
        {
            var shingles = new Dictionary<string, int>();

            var string_no_space = SPACE_REG.Replace(s, " ");

            for (int i = 0; i < (string_no_space.Length - k + 1); i++)
            {
                var shingle = string_no_space.Substring(i, k);

                if (shingles.TryGetValue(shingle, out var old))
                {
                    shingles[shingle] = old + 1;
                }
                else
                {
                    shingles[shingle] = 1;
                }
            }

            return new ReadOnlyDictionary<string, int>(shingles);
        }
        public JacardIndex() : this(DEFAULT_K) {
        }
        public double Similarity(string s1, string s2)
        {
            if (s1 == null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (s2 == null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            if (s1.Equals(s2))
            {
                return 1;
            }

            var profile1 = GetProfile(s1);
            var profile2 = GetProfile(s2);

            var union = new HashSet<string>();
            union.UnionWith(profile1.Keys);
            union.UnionWith(profile2.Keys);

            int inter = profile1.Keys.Count + profile2.Keys.Count
                        - union.Count;

            return (double)inter / union.Count;
        }


    }
}