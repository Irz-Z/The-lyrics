using System.Collections.Generic;
using System.Linq;
using TheLyrics.Api;
using Pinyin;

namespace TheLyrics.Core.DiffSinger {
    [Phonemizer("DiffSinger Jyutping Phonemizer", "DIFFS ZH-YUE", language: "ZH-YUE")]
    public class DiffSingerJyutpingPhonemizer : DiffSingerBasePhonemizer {
        protected override string GetDictionaryName() => "dsdict-zh-yue.yaml";
        public override string GetLangCode() => "yue";
        protected override string[] Romanize(IEnumerable<string> lyrics) {
            return Pinyin.Jyutping.Instance.HanziToPinyin(lyrics.ToList(), CanTone.Style.NORMAL, Pinyin.Error.Default).Select(res => res.pinyin).ToArray();
        }
    }
}
