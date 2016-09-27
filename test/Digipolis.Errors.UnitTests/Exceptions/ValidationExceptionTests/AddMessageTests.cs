﻿using System;
using System.Linq;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.ValidationExceptionTests
{
    public class AddMessageTests
    {
        [Fact]
        private void MessageIsAddedToMessagesCollectionWithDefaultKey()
        {
            var ex = new ValidationException();
            ex.AddMessage("aMessage");

            Assert.Equal(1, ex.Messages.Count);
            Assert.Contains("aMessage", ex.Messages.First().Value);
            Assert.Equal(Defaults.ErrorMessage.Key, ex.Messages.First().Key);
        }

        [Fact]
        private void KeyAndMessageAreAddedToMessagesCollection()
        {
            var ex = new ValidationException();
            ex.AddMessage("aKey", "aMessage");

            Assert.Equal(1, ex.Messages.Count);
            Assert.Equal("aKey", ex.Messages.First().Key);
            Assert.Contains("aMessage", ex.Messages.First().Value);
        }

        [Fact]
        private void NullKeyThrowsArgumentNullException()
        {
            var ex = new ValidationException();
            var result = Assert.Throws<ArgumentNullException>(() => ex.AddMessage(null, "aMessage"));
            Assert.Equal("key", result.ParamName);
        }

        [Fact]
        private void NullMessageWithValidKeyIsNotAddedToMessagesCollection()
        {
            var ex = new ValidationException();
            ex.AddMessage("aKey", null);
            Assert.Equal(0, ex.Messages.Count);
        }

        [Fact]
        private void NullMessagesOnlyIsNotAddedToMessagesCollection()
        {
            var ex = new ValidationException();
            ex.AddMessage(null);
            ex.AddMessage(string.Empty);
            Assert.Equal(0, ex.Messages.Count);
        }

        [Fact]
        private void DefaultEmptyKeyAddsToCollection()
        {
            var ex = new ValidationException();
            ex.AddMessage(Defaults.ErrorMessage.Key, "aMessage");

            Assert.Equal(1, ex.Messages.Count);
            Assert.Contains("aMessage", ex.Messages.First().Value);
        }
    }
}
