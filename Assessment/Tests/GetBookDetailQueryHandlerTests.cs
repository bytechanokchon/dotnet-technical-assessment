using Applications;
using Applications.DTOs.Books;
using Applications.Handlers.Books.Queries;
using Applications.Services;
using Moq;

namespace Tests
{
    public class GetBookDetailQueryHandlerTests
    {
        private readonly Mock<IServiceUnitOfWork> _serviceUnitOfWorkMock;
        private readonly Mock<IExternalBookService> _externalBookServiceMock;

        private readonly GetBookDetailQuery.GetBookDetailQueryHandler _handler;

        public GetBookDetailQueryHandlerTests()
        {
            _serviceUnitOfWorkMock = new Mock<IServiceUnitOfWork>();
            _externalBookServiceMock = new Mock<IExternalBookService>();

            _serviceUnitOfWorkMock
                .Setup(x => x.ExternalBookService)
                .Returns(_externalBookServiceMock.Object);

            _handler =
                new GetBookDetailQuery.GetBookDetailQueryHandler(
                    _serviceUnitOfWorkMock.Object
                );
        }

        [Fact]
        public async Task Handle_ShouldReturnBookDetail_WhenExternalApiReturnsData()
        {
            // Arrange

            var bookDetail = new BookExternalDto
            {
                ChapterNo = 2,
                VerseNo = 2,
                Language = "AAA",
                ChapterName = "2. ସାଂଖ୍ୟ ଯୋଗ",
                Verse = "ଶ୍ରୀଭଗବାନ ଉବାଚ\nକୁତସ୍ତ୍ୱା କଶ୍ମଳମିଦଂ ବିଷମେ ସମୁପସ୍ଥିତମ୍ ।\nଅନାର୍ଯ୍ୟଜୁଷ୍ଟମସ୍ୱର୍ଗ୍ୟମକୀର୍ତିକରମର୍ଜୁନ ।।୨।।",
                Translation = string.Empty,
                Synonyms = "ଶ୍ରୀଭଗବାନ ଉବାଚ-ପରମ ପୁରୁଷ ଭଗବାନ କହିଲେ; କୁତଃ- କେଉଁଠାରୁ; ତ୍ୱା-ତୁମ ପାଖକୁ; କଶ୍ମଳଂ-ଅଜ୍ଞାନ; ଇଦଂ-ଏହି ; ବିଷମେ- ବିଷମ ସମୟରେ; ସମୁପସ୍ଥିତମ୍‌-ଉପସ୍ଥିତ ହେଲା; ଅନାର୍ଯ୍ୟ- ଅଜ୍ଞାନୀ ବ୍ୟକ୍ତି; ଜୁଷ୍ଟଂ- ଅଭ୍ୟାସ କରାଯାଉଥିବା; ଅସ୍ୱର୍ଗ୍ୟମ୍‌- ଯାହା ଉଚ୍ଚତର ଲୋକକୁ ଯିବାକୁ ଦିଏନାହିଁ; ଅକୀର୍ତିକରଂ-ଯାହା ଅପଯଶର କାରଣ; ଅର୍ଜୁନ-ହେ ଅର୍ଜୁନ ।",
                AudioLink = "https://www.holy-bhagavad-gita.org/public/audio/002_002.mp3",
                Transliteration = "ଭଗବାନ କହିଲେ, ପ୍ରିୟ ଅର୍ଜୁନ! ଏହି ବିପଦପୂର୍ଣ୍ଣ ସମୟରେ ଏପରି ଦ୍ୱନ୍ଦ୍ୱ ତୁମଠାରେ ଉତ୍ପନ୍ନ ହେଲା କିପରି? ଏହା ଏକ ଯଶସ୍ୱୀ ପୁରୁଷକୁ ଶୋଭା ଦିଏନାହିଁ । ଏହା ଉଚ୍ଚଲୋକକୁ ନ ନେଇ ଅପଯଶ ପ୍ରଦାନ କରିଥାଏ ।",
                Purport = new List<string>()
                {
                    "ଆମ ଧର୍ମଗ୍ରନ୍ଥମାନଙ୍କରେ ଆର୍ଯ୍ୟ ଶବ୍ଦଟି କୌଣସି ଏକ ଜାତି ବା ଜାତୀୟତାକୁ ସୂଚିତ କରି ନ ଥାଏ । ମନୁସ୍ମୃତି ଅନୁଯାୟୀ ଜଣେ ଅତ୍ୟଧିକ ବିକଶିତ ଏବଂ ସଭ୍ୟ ବ୍ୟକ୍ତିଙ୍କୁ ଆର୍ଯ୍ୟ କୁହାଯାଏ । “ଆର୍ଯ୍ୟ” ଏକ ସଦ୍‌ଗୁଣକୁ ସୂଚିତ କରିଥାଏ, ଯେପରିକି ଜଣେ ଭଦ୍ରଲୋକ । ବୈଦିକ ଶାସ୍ତ୍ରମାନଙ୍କର ଉଦ୍ଦେଶ୍ୟ ହେଉଛି, ମନୁଷ୍ୟକୁ ସବୁ ଦିଗରୁ ଆର୍ଯ୍ୟ ହେବା ପାଇଁ ପ୍ରେରିତ କରିବା । ଶ୍ରୀକୃଷ୍ଣ ଦେଖୁଛନ୍ତି ଅର୍ଜୁନଙ୍କର ବର୍ତ୍ତମାନ ସ୍ଥିତି ସେହି ଆଦର୍ଶ ଅନୁରୂପ ନୁହେଁ ଏବଂ ତାଙ୍କର ଦ୍ୱନ୍ଦ୍ୱ ପ୍ରତି ଧ୍ୟାନ ଆକର୍ଷଣ କରି ସେ ତାଙ୍କୁ ସ୍ନେହପୂର୍ଣ୍ଣ ଭର୍ତ୍ସନା କରୁଛନ୍ତି କିପରି ବର୍ତ୍ତମାନ ସ୍ଥିତିରେ ମଧ୍ୟ ସେ ସେହି ଆଦର୍ଶରେ ସ୍ଥିତ ରହିପାରିବେ ।\",\r\n      \"ଭଗବଦ୍ ଗୀତା ବା ‘ଭଗବାନଙ୍କର ଗୀତ’ ଯଥାର୍ଥରେ ଏହିଠାରୁ ହିଁ ଆରମ୍ଭ ହୋଇଛି, କାରଣ ଶ୍ରୀକୃଷ୍ଣ, ଯିଏ ବର୍ତ୍ତମାନ ସୁଦ୍ଧା ପର୍ଯ୍ୟନ୍ତ ଚୁପ୍ ରହିଥିଲେ, ଏହି ଶ୍ଳୋକ ଠାରୁ କହିବାକୁ ଆରମ୍ଭ କରିଛନ୍ତି । ପ୍ରଥମେ ସେ ଅର୍ଜୁନଙ୍କ ମନରେ ଜ୍ଞାନ ପ୍ରତି କ୍ଷୁଧା ଉତ୍ପନ୍ନ କରାଇଛନ୍ତି ।  ସେହି ଉଦ୍ଦେଶ୍ୟରେ ସେ କହୁଛନ୍ତି ଯେ ତାଙ୍କର ଏହି ଦ୍ୱନ୍ଦ୍ୱ ଜଣେ ଧର୍ମାତ୍ମାଙ୍କ ପକ୍ଷରେ ଅନୈତିକ ଓ ଅନୁପଯୁକ୍ତ ଅଟେ । ତାପରେ ସେ ଅର୍ଜୁନଙ୍କୁ ସ୍ମରଣ କରାଇ ଦେଉଛନ୍ତି ଯେ ମୋହର ପରିଣାମ କଷ୍ଟ, ଅପଯଶ, ଜୀବନରେ ବିଫଳତା ଏବଂ ଆତ୍ମାର ଅଧୋଗତି ଅଟେ ।",
                    "ତାଙ୍କୁ ସାନ୍ତ୍ୱନା ଦେବା ପରିବର୍ତ୍ତେ, ଶ୍ରୀକୃଷ୍ଣ ଅର୍ଜୁନଙ୍କୁ ତାଙ୍କର ବର୍ତ୍ତମାନ ସ୍ଥିତିକୁ ନେଇ ଅଶାନ୍ତ କରିଦେଉଛନ୍ତି । ଆମେ ସମସ୍ତେ ଦ୍ୱିଧା ଗ୍ରସ୍ତ ହେଲେ ଆଶାନ୍ତି ଅନୁଭବ କରିଥାଏ କାରଣ ଏହା ଆତ୍ମାର ସ୍ୱାଭାବିକ ସ୍ଥିତି ନୁହେଁ । ଅସନ୍ତୋଷର ଏହି ଅନୁଭୂତି, ଯଦି ଠିକ୍ ମାର୍ଗରେ ପରିଚାଳିତ ହୁଏ, ତେବେ ତାହା ପ୍ରକୃତ ଜ୍ଞାନ ଅନ୍ୱେଷଣର ଏକ ଶକ୍ତିଶାଳୀ ଅଭିପ୍ରେରଣା ହୋଇପାରିବ । ସଂଶୟର ସଠିକ୍ ସମାଧାନ ସେହି ବିଷୟରେ ବ୍ୟକ୍ତିର ଜ୍ଞାନକୁ ପୂର୍ବାପେକ୍ଷା ଅଧିକ ଗଭୀର କରିଥାଏ । ସେଥିପାଇଁ ଭଗବାନ ବେଳେ ବେଳେ ବ୍ୟକ୍ତିକୁ ଜାଣିଶୁଣି ଜଟିଳ ପରିସ୍ଥିତିର ସମ୍ମୁଖୀନ କରାଇ ଥାଆନ୍ତି, ଯଦ୍ୱାରା ସେ ନିଜ ଦ୍ୱନ୍ଦ୍ୱର ସମାଧାନ ପାଇଁ ସତ୍ୟର ଅନ୍ୱେଷଣ କରିବାକୁ ବାଧ୍ୟ ହୁଏ ଏବଂ ପରିଶେଷରେ ଯେତେବେଳେ ସଂଶୟର ସମାଧାନ ହୋଇଯାଏ, ବ୍ୟକ୍ତି ଜ୍ଞାନର ଉଚ୍ଚତର ସୋପାନରେ ପହଞ୍ôଚଯାଏ ।"
                }
            };

            _externalBookServiceMock
                .Setup(x => x.GetExternalBookAsync())
                .ReturnsAsync(bookDetail);

            _externalBookServiceMock
                .Setup(x => x.BaseUrl)
                .Returns("https://example.com/odi/verse/2/2");

            var query = new GetBookDetailQuery();

            // Act

            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert

            Assert.NotNull(result);

            Assert.NotNull(result.Response);

            _externalBookServiceMock.Verify(
                x => x.GetExternalBookAsync(),
                Times.Once
            );
        }
    }
}
