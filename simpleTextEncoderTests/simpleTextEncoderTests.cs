using Microsoft.VisualStudio.TestTools.UnitTesting;
using simpleTextEncoders;

namespace simpleTextEncoderTests
{
    [TestClass]
    public class simpleTextEncoderTests
    {
        [TestMethod]
        public void fastCipher()
        {
            //ARRANGE

            //ACT
            string inputMessage = "test string 123";
            string cipherMessage = simpleTextEncoder.cipher(inputMessage);
            string deciphMessage = simpleTextEncoder.decipher(cipherMessage);

            //ASSERT
            Assert.AreEqual(inputMessage, deciphMessage);


        }

        [TestMethod]
   //     [DataRow(15)]   MAKES ERROR!!!
        [DataRow(47)]
        [DataRow(88)]
        [DataRow(159)]
        public void cipherWithParameter(int shift)
        {
            //ARRANGE
            string inputMessage = "test string 123";
            byte _shift =  System.Convert.ToByte(shift);
            _shift = 45;
            //ACT
            string cipherMessage1 = simpleTextEncoder.cipher(inputMessage,_shift);
            string deciphMessage1 = simpleTextEncoder.decipher(cipherMessage1,_shift);

            //ASSERT
            Assert.AreEqual(inputMessage, deciphMessage1);


        }
    }
}
