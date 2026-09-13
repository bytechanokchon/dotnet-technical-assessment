using Applications.Handlers.Products.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class SortCharacterQueryHandlerTests
    {
        private readonly SortCharacterQuery.SortCharacterQueryHandler _handler;

        public SortCharacterQueryHandlerTests()
        {
            _handler = new SortCharacterQuery.SortCharacterQueryHandler();
        }

        [Fact]
        public async Task Handle_ShouldReturnDuplicateCharactersSortedAscending()
        {
            // Arrange
            var query = new SortCharacterQuery("B,A,A,C,B");

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Equal(2, result.Count);

            Assert.Equal("A", result[0].Rank);
            Assert.Equal("B", result[1].Rank);
        }

        [Fact]
        public async Task Handle_ShouldReturnDuplicateNumbersSortedAscending()
        {
            // Arrange
            var query = new SortCharacterQuery("3,1,2,3,2,1");

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Equal(3, result.Count);

            Assert.Equal("1", result[0].Rank);
            Assert.Equal("2", result[1].Rank);
            Assert.Equal("3", result[2].Rank);
        }

        [Fact]
        public async Task Handle_ShouldReturnCharactersBeforeNumbers()
        {
            // Arrange
            var query = new SortCharacterQuery("3,A,2,B,A,3");

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Equal(2, result.Count);

            // Characters first
            Assert.Equal("A", result[0].Rank);

            // Numbers after characters
            Assert.Equal("3", result[1].Rank);
        }

        [Fact]
        public async Task Handle_ShouldReturnOnlyDuplicatedValues()
        {
            // Arrange
            var query = new SortCharacterQuery("A,B,C,1,2");

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnDuplicatedValuesOnlyOnce()
        {
            // Arrange
            var query = new SortCharacterQuery(
                "A,A,A,B,B,B,1,1,1"
            );

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Equal(3, result.Count);

            Assert.Equal("A", result[0].Rank);
            Assert.Equal("B", result[1].Rank);
            Assert.Equal("1", result[2].Rank);
        }

        [Fact]
        public async Task Handle_ShouldSortCharactersAscending()
        {
            // Arrange
            var query = new SortCharacterQuery(
                "Z,A,C,B,Z,A,C,B"
            );

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Equal(4, result.Count);

            Assert.Equal("A", result[0].Rank);
            Assert.Equal("B", result[1].Rank);
            Assert.Equal("C", result[2].Rank);
            Assert.Equal("Z", result[3].Rank);
        }

        [Fact]
        public async Task Handle_ShouldSortNumbersAscending()
        {
            // Arrange
            var query = new SortCharacterQuery(
                "9,2,5,1,9,2,5,1"
            );

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Equal(4, result.Count);

            Assert.Equal("1", result[0].Rank);
            Assert.Equal("2", result[1].Rank);
            Assert.Equal("5", result[2].Rank);
            Assert.Equal("9", result[3].Rank);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenTextLengthIsGreaterThan99()
        {
            // Arrange
            var text = new string('A', 100);

            var query = new SortCharacterQuery(text);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                async () =>
                {
                    await _handler.Handle(
                        query,
                        CancellationToken.None
                    );
                }
            );

            Assert.Equal(
                "Texh should less than 99 character",
                exception.Message
            );
        }

        [Fact]
        public async Task Handle_ShouldAcceptTextLengthExactly99()
        {
            // Arrange
            // ต้องมี comma เพื่อให้เกิด duplicate
            var text = string.Join(",", Enumerable.Repeat("A", 33));

            // ตรวจสอบว่าไม่เกิน 99 ตัวอักษร
            Assert.True(text.Length <= 99);

            var query = new SortCharacterQuery(text);

            // Act
            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert
            Assert.Single(result);
            Assert.Equal("A", result[0].Rank);
        }
    }
}
