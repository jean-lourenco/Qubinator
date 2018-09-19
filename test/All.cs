using Qubinator.Lib;
using System;
using Xunit;

namespace Qubinator.Tests
{
    public class All
    {
        [Fact]
        public void Qubinator_Should_Generate_Correct_2D_Simple_Board()
        {
            var result = Quber.To2DSimple("BATATINHA");

            var expected =
@"BATATINHA
A        
T        
A        
T        
I        
N        
H        
A        
";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Qubinator_Should_Generate_Correct_2D_Full_Board()
        {
            var result = Quber.To2DFull("BATATINHA");

            var expected =
@"BATATINHA
A       H
T       N
A       I
T       T
I       A
N       T
H       A
AHNITATAB
";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Qubinator_Should_Generate_Correct_3D_Board_With_Long_Word()
        {
            var result = Quber.To3D("BATATINHA");

            var expected =
@"BATATINHA   
A\      H\  
T \     N \ 
A  BATATINHA
T  A    T  H
I  T    A  N
N  A    T  I
H  T    A  T
AHNITATAB  A
 \ N     \ T
  \H      \A
   AHNITATAB
";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Qubinator_Should_Generate_Correct_3D_Board_With_Short_Word()
        {
            var result = Quber.To3D("PASITO");

            var expected =
@"PASITO   
A\   T\  
S \  I \ 
I  PASITO
T  A A  T
OTISAP  I
 \ I  \ S
  \T   \A
   OTISAP
";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Qubinator_Should_Generate_Correct_Full_Offseted_Text()
        {
            var result = Quber.ToFullTextOffset("BETELGEUSE");

            var expected =
@"BETELGEUSE
ETELGEUSEB
TELGEUSEBE
ELGEUSEBET
LGEUSEBETE
GEUSEBETEL
EUSEBETELG
USEBETELGE
SEBETELGEU
EBETELGEUS
";

            Assert.Equal(expected, result);
        }

        [Fact]
        void Qubinator_Should_Throw_Exception_If_Word_Has_Less_Than_3_Letters()
        {
            string wordNull = null;
            var word = "OI";

            Assert.Throws<ArgumentNullException>(() => Quber.To2DFull(wordNull));
            Assert.Throws<ArgumentException>(() => Quber.To2DFull(word));

            Assert.Throws<ArgumentNullException>(() => Quber.To2DSimple(wordNull));
            Assert.Throws<ArgumentException>(() => Quber.To2DSimple(word));

            Assert.Throws<ArgumentNullException>(() => Quber.To3D(wordNull));
            Assert.Throws<ArgumentException>(() => Quber.To3D(word));

            Assert.Throws<ArgumentNullException>(() => Quber.ToFullTextOffset(wordNull));
            Assert.Throws<ArgumentException>(() => Quber.ToFullTextOffset(word));
        }
    }
}
