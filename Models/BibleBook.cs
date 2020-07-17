using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllWithOneAccord.Models
{
    public class BibleBook
    {
        public string Name { get; set; }

        public BookChapter[] BookChapters { get; set; }
    }

    public class BookChapter
    {
        public long Number { get; set; }
        public string BookName { get; set; }
        public string ChapterName { get; set; }

        public ChapterAudio[] Audios { get; set; }
        
        public Verse[] Verses { get; set; }
    }

    public class ChapterAudio
    {
        public int ChapterNumber { get; set; }

        public string ChapterReader { get; set; }

        public string ChapterPath { get; set; }

        public string ChapterSplitting { get; set; }
        public decimal StartsAt { get; set; }
        public decimal EndsAt { get; set; }
    }

    public class Verse
    {
        public long Number { get; set; }

        public string Text { get; set; }
    }
}