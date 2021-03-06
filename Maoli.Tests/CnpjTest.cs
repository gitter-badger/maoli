﻿namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Xunit;

    public class CnpjTest
    {
        private const string looseValidCnpj = "63943315000192";

        private const string looseInvalidCnpj = "32343315/000134";

        private const string strictValidCnpj = "63.943.315/0001-92";

        private const string strictInvalidCnpj = "32.343.315/0001-34";

        [Fact]
        public void PunctuationReturnsStrict()
        {
            var cnpj = Cnpj.Parse(CnpjTest.strictValidCnpj, CnpjPunctuation.Strict);
            var expected = CnpjPunctuation.Strict;
            var actual = cnpj.Punctuation;

            Assert.Equal<CnpjPunctuation>(expected, actual);
        }

        [Fact]
        public void PunctuationReturnsLoose()
        {
            var cnpj = Cnpj.Parse(CnpjTest.looseValidCnpj, CnpjPunctuation.Loose);
            var expected = CnpjPunctuation.Loose;
            var actual = cnpj.Punctuation;

            Assert.Equal<CnpjPunctuation>(expected, actual);
        }

        [Fact]
        public void LooseParseReturnsACnpjObjectIfCnpjIsValid()
        {
            var cnpj = Cnpj.Parse(CnpjTest.looseValidCnpj);

            Assert.NotNull(cnpj);
        }

        [Fact]
        public void LooseParseReturnsACnpjObjectIfFormattedCnpjIsValid()
        {
            var cnpj = Cnpj.Parse(CnpjTest.strictValidCnpj);

            Assert.NotNull(cnpj);
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCnpjIsNotValid()
        {
            var actual = false;

            try
            {
                Cnpj.Parse(CnpjTest.looseInvalidCnpj);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCnpjIsEmpty()
        {
            var actual = false;

            try
            {
                Cnpj.Parse(string.Empty);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCnpjIsNull()
        {
            var actual = false;

            try
            {
                Cnpj.Parse(null);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACnpjObjectIfCnpjIsEmpty()
        {
            var actual = false;

            try
            {
                Cnpj.Parse(string.Empty, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACnpjObjectIfCnpjIsInvalid()
        {
            var actual = false;

            try
            {
                Cnpj.Parse(CnpjTest.looseValidCnpj, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACnpjObjectIfCnpjIsNull()
        {
            var actual = false;

            try
            {
                Cnpj.Parse(null, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseReturnsACnpjObjectIfFormattedCnpjIsValid()
        {
            var cnpj = Cnpj.Parse(CnpjTest.strictValidCnpj, CnpjPunctuation.Strict);

            Assert.NotNull(cnpj);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionIfCnpjIsFormatted()
        {
            var actual = false;

            try
            {
                Cnpj.Parse(CnpjTest.looseValidCnpj, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void ValidateReturnsTrueIfCnpjIsValid()
        {
            var actual = Cnpj.Validate(CnpjTest.looseValidCnpj);

            Assert.True(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjIsInvalid()
        {
            var actual = Cnpj.Validate(CnpjTest.looseInvalidCnpj);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjIsEmpty()
        {
            var actual = Cnpj.Validate(string.Empty);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjContainsInvalidChars()
        {
            var actual = Cnpj.Validate("714o256s8");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjIsLooseAndGreaterThanFourteenCaracters()
        {
            var actual = Cnpj.Validate("12345678901234567890");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjIsValidButNotStrict()
        {
            var actual = Cnpj.Validate(looseValidCnpj, CnpjPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsTrueIfCnpjIsValidAndStrict()
        {
            var actual = Cnpj.Validate(CnpjTest.strictValidCnpj, CnpjPunctuation.Strict);

            Assert.True(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjIsInvalidAndStrict()
        {
            var actual = Cnpj.Validate(CnpjTest.strictInvalidCnpj, CnpjPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjIsHalfPunctuatedAndValidAndLoose()
        {
            var actual = Cnpj.Validate("63.9433150001-92", CnpjPunctuation.Loose);

            Assert.False(actual);
        }

        [Fact]
        public void CompleteReturnsAValidCnpj()
        {
            var actual = Cnpj.Complete("639433150001");

            Assert.Equal(CnpjTest.looseValidCnpj, actual);
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCnpjTextIsWrong()
        {
            var actual = false;

            try
            {
                Cnpj.Complete("714o256s8");
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCnpjTextIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Cnpj.Complete(null);
            });
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCnpjTextIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Cnpj.Complete(null);
            });
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsTrueIfSameCnpjIsEqual()
        {
            var cnpj = Cnpj.Parse(looseValidCnpj);

            var actual = cnpj.Equals(cnpj);

            Assert.True(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsTrueIfTwoCnpjsAreReciprocal()
        {
            var Cnpj1 = Cnpj.Parse(looseValidCnpj);
            var Cnpj2 = Cnpj.Parse(looseValidCnpj);

            var actual = Cnpj1.Equals(Cnpj2) && Cnpj2.Equals(Cnpj1);

            Assert.True(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsTrueIfThreeCnpjsAreReciprocal()
        {
            var Cnpj1 = Cnpj.Parse(looseValidCnpj);
            var Cnpj2 = Cnpj.Parse(looseValidCnpj);
            var Cnpj3 = Cnpj.Parse(looseValidCnpj);

            var actual = Cnpj1.Equals(Cnpj2) && Cnpj2.Equals(Cnpj3) && Cnpj1.Equals(Cnpj3);

            Assert.True(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsFalseIfCnpjIsNull()
        {
            var cnpj = Cnpj.Parse(looseValidCnpj);

            var actual = cnpj.Equals(null);

            Assert.False(actual);
        }

        [Fact]
        public void EqualsReturnsTrueIfCnpjAreEqual()
        {
            var cnpj1 = Cnpj.Parse(looseValidCnpj);
            var cnpj2 = Cnpj.Parse(looseValidCnpj);

            var actual = cnpj1.Equals(cnpj2);

            Assert.True(actual);
        }

        [Fact]
        public void EqualsReturnsTrueIfCnpjAreEqualButWithDiffPunctuation()
        {
            var cnpj1 = Cnpj.Parse(looseValidCnpj);
            var cnpj2 = Cnpj.Parse(strictValidCnpj, CnpjPunctuation.Strict);

            var actual = cnpj1.Equals(cnpj2);

            Assert.True(actual);
        }

        [Fact]
        public void EqualsReturnsFalseIfCnpjAreNotEqual()
        {
            var cnpj1 = Cnpj.Parse(looseValidCnpj);
            var cnpj2 = Cnpj.Parse("71418811000155");

            var actual = cnpj1.Equals(cnpj2);

            Assert.False(actual);
        }

        [Fact]
        public void GetHashCodeAreEqualIfTwoCnpjAreEqual()
        {
            var hash1 = Cnpj.Parse(looseValidCnpj).GetHashCode();
            var hash2 = Cnpj.Parse(looseValidCnpj).GetHashCode();

            Assert.Equal<int>(hash1, hash2);
        }

        [Fact]
        public void GetHashCodeReturnsTrueIfCnpjAreEqualButWithDiffPunctuation()
        {
            var hash1 = Cnpj.Parse(looseValidCnpj).GetHashCode();
            var hash2 = Cnpj.Parse(strictValidCnpj).GetHashCode();

            Assert.Equal<int>(hash1, hash2);
        }

        [Fact]
        public void GetHashCodeReturnsFalseIfTwoCnpjAreNotEqual()
        {
            var hash1 = Cnpj.Parse(looseValidCnpj).GetHashCode();
            var hash2 = Cnpj.Parse("71418811000155").GetHashCode();

            Assert.NotEqual<int>(hash1, hash2);
        }

        [Fact]
        public void ToStringReturnsStringWithNoPunctuationIfCnpjPunctuationIsStrict()
        {
            var Cnpj = new Cnpj(strictValidCnpj, CnpjPunctuation.Strict);

            var expected = looseValidCnpj;
            var actual = Cnpj.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringReturnsStringWithNoPunctuationIfCnpjPunctuationIsLoose()
        {
            var Cnpj = new Cnpj(looseValidCnpj);

            var expected = looseValidCnpj;
            var actual = Cnpj.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryParseReturnsFalseIfCnpjIsInvalid()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(looseInvalidCnpj, out Cnpj);

            Assert.False(actual);
        }

        [Fact]
        public void TryParseReturnsTrueIfCnpjIsValid()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(looseValidCnpj, out Cnpj);

            Assert.True(actual);
        }

        [Fact]
        public void StrictTryParseReturnsFalseIfCnpjIsInvalid()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(looseInvalidCnpj, out Cnpj, CnpjPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void StrictTryParseReturnsTrueIfCnpjIsValidAndHasPunctuation()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(strictValidCnpj, out Cnpj, CnpjPunctuation.Strict);

            Assert.True(actual);
        }
    }
}