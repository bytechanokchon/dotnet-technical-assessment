using Applications.DTOs.Products;
using MediatR;

namespace Applications.Handlers.Products.Commands
{
    public class SortCharacterQuery : IRequest<List<CharacterRankDto>>
    {
        public SortCharacterQuery(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public class SortCharacterQueryHandler : IRequestHandler<SortCharacterQuery, List<CharacterRankDto>>
        {
            public async Task<List<CharacterRankDto>> Handle(SortCharacterQuery request, CancellationToken cancellationToken)
            {
                List<string> words = new List<string>();

                string[] wordSpliteds = request.Text.Split(",");

                // กรองข้อมูลดิบ เอาเฉพาะคำที่มีตัวซ้ำ
                for (int currentIndex = 0;  currentIndex < wordSpliteds.Length; currentIndex++)
                {
                    string currentWord = wordSpliteds[currentIndex];

                    for (int nextIndex = currentIndex + 1; nextIndex < wordSpliteds.Length; nextIndex++)
                    {
                        string nextWord = wordSpliteds[nextIndex];

                        if (currentWord.Equals(nextWord))
                        {
                            bool isDupplicate = false;

                            for (var filterIndex = 0; filterIndex < words.Count; filterIndex++)
                            {
                                string wordFilter = words[filterIndex];

                                if (wordFilter.Equals(currentWord))
                                {
                                    isDupplicate = true;
                                    break;
                                }
                            }

                            if (!isDupplicate)
                            {
                                words.Add(currentWord);
                            }
                            
                        }
                    }
                }

                // แบ่งข้อมูลออกเป็น 2 กลุ่ม คือ กลุ่มของตัวอักษร และ กลุ่มของตัวเลข
                List<string> wordFiltereds = new List<string>();
                List<string> numberFiltereds = new List<string>();

                foreach (string word in words)
                {
                    bool isOnlyNumber = true;

                    foreach (char ch in word)
                    {
                        char minNumber = '0';
                        char maxNumber = '9';

                        if (ch < minNumber || ch > maxNumber)
                        {
                            isOnlyNumber = false;
                            break;
                        }
                    }

                    if (isOnlyNumber)
                    {
                        numberFiltereds.Add(word);
                    }
                    else
                    {
                        wordFiltereds.Add(word);
                    }
                }

                List<CharacterRankDto> characterRankDtos = new List<CharacterRankDto>();

                foreach (var wordFiltered in wordFiltereds.OrderBy(x => x).ToList())
                {
                    characterRankDtos.Add(new CharacterRankDto()
                    {
                        Rank = wordFiltered
                    });
                }

                foreach (string numberFiltered in numberFiltereds.OrderBy(x => x).ToList())
                {
                    characterRankDtos.Add(new CharacterRankDto()
                    {
                        Rank = numberFiltered
                    });
                }

                return characterRankDtos;
            }
        }
    }
}
