using Xunit;

namespace Qubinator.Tests
{
    public class Tests
    {
        [Fact]
        public void Qubinator_Should_Generate_Correct_2D_Simple_Board()
        {
            var quber = new Quber();

            var result = quber.To2DSimple("BATATINHA");

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
            var quber = new Quber();

            var result = quber.To2DFull("BATATINHA");

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
            var quber = new Quber();

            var result = quber.To3D("BATATINHA");

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
            var quber = new Quber();

            var result = quber.To3D("PASITO");

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
            var quber = new Quber();

            var result = quber.ToFullTextOffset("BETELGEUSE");

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
    }
}
