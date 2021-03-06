﻿using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Model;
using Xunit;

namespace Tesla.Tests.Model.AuthModel
{
    public class IsPinValidTest
    {

        public IOperation<bool> GetOperation(string pin)
        {
            return new IsPinValid(pin).Operation;
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("123")]
        [InlineData("12345")]
        public async Task AuthenticateOnPinLengthTest(string pin)
        {
            Assert.Equal(pin?.Length == BusinessRules.PinLength, await GetOperation(pin).Function(new System.Threading.CancellationToken()));
        }

        [Theory]
        [InlineData(".")]
        [InlineData("....")]
        [InlineData("ghyt")]
        [InlineData("66.8")]
        [InlineData(null)]
        public async Task InvalidCharactersTest(string pin)
        {
            Assert.Equal(false, await GetOperation(pin).Function(new System.Threading.CancellationToken()));
        }
    }
}
