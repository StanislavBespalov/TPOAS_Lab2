using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursework;
using System;
using System.IO;

namespace Coursework.Tests
{
    [TestClass]
    public class TelephoneAbonentsTests
    {
        [TestMethod]
        public void DataFind_MatchingFIO_ReturnsData()
        {
            //���� �������� ��� ��������� � ������� �������, ����� dataFind ������ ������� ��� � ��� ��������� ��������
            var abonent = new TelephoneAbonents("Test FIO", "+7-123-456-78-90", 2020);
            var sw = new StringWriter();
            Console.SetOut(sw);

            abonent.dataFind("Test FIO");

            var output = sw.ToString();
            Assert.IsTrue(output.Contains("Test FIO"));
            Assert.IsTrue(output.Contains("2020"));
        }

        [TestMethod]
        public void DataFind_NonMatchingFIO_ReturnsNothing()
        {
            //���� ��� �� ��������� � ������� �������, ����� dataFind �� ������ ������ ��������
            var abonent = new TelephoneAbonents("Test FIO", "+7-123-456-78-90", 2020);
            var sw = new StringWriter();
            Console.SetOut(sw);

            abonent.dataFind("Wrong FIO");

            var output = sw.ToString();
            Assert.IsFalse(output.Contains("Test FIO"));
        }

        [TestMethod]
        public void FioSkip_DifferentFIO_ReturnsTrue()
        {
            //����� fioSkip ������ ���������� true, ���� ��� ������� �� ��������� � ��������� ���
            var abonent = new TelephoneAbonents("Test FIO", "+7-123-456-78-90", 2020);
            var massive2 = new TelephoneAbonents { fioDel = "Other FIO" };
            int k = 5;

            var result = abonent.fioSkip(ref k, massive2);

            Assert.IsTrue(result);
            Assert.AreEqual(5, k);
        }

        [TestMethod]
        public void FioSkip_MatchingFIO_ReturnsFalseAndDecrementsK()
        {
            //����� fioSkip ������ ���������� false � ��������� ������� K, ���� ��� ������� ��������� � ���������
            var abonent = new TelephoneAbonents("Test FIO", "+7-123-456-78-90", 2020);
            var massive2 = new TelephoneAbonents { fioDel = "Test FIO" };
            int k = 5;

            var result = abonent.fioSkip(ref k, massive2);

            Assert.IsFalse(result);
            Assert.AreEqual(4, k);
        }

        [TestMethod]
        public void NumberFioRename_MatchingNumber_UpdatesFIO()
        {
            //���� ����� �������� ������� ��������� � ���������, ����� numberFioRename ������ �������� ��� �� ����� ��������
            var abonent = new TelephoneAbonents("Old FIO", "+7-123-456-78-90", 2020);
            var massive2 = new TelephoneAbonents { numberDel = "+7-123-456-78-90" };
            var input = new StringReader("New FIO");
            Console.SetIn(input);

            abonent.numberFioRename(massive2);

            Assert.AreEqual("New FIO", abonent.fio);
        }

        [TestMethod]
        public void NumberFioRename_NonMatchingNumber_DoesNotUpdate()
        {
            //���� ����� �������� ������� �� ��������� � ���������, ����� numberFioRename �� ������ ������ ���
            var abonent = new TelephoneAbonents("Old FIO", "+7-123-456-78-90", 2020);
            var massive2 = new TelephoneAbonents { numberDel = "other-number" };

            abonent.numberFioRename(massive2);

            Assert.AreEqual("Old FIO", abonent.fio);
        }

        [TestMethod]
        public void ShowData_OutputsCorrectData()
        {
            //����� showData ������ �������� ���, ����� �������� � ��� ��������� � ���������� �������
            var abonent = new TelephoneAbonents("Test FIO", "+7-123-456-78-90", 2020);
            var sw = new StringWriter();
            Console.SetOut(sw);

            abonent.showData();

            var output = sw.ToString();
            Assert.IsTrue(output.Contains("Test FIO"));
            Assert.IsTrue(output.Contains("+7-123-456-78-90"));
            Assert.IsTrue(output.Contains("2020"));
        }

        [TestMethod]
        public void ShowData2_OutputsCorrectData()
        {
            //����� showData2 ������ �������� ��� � ����� �������� �� ���������� �����
            var abonent = new TelephoneAbonents();
            abonent.fioDel = "Test FIO";
            abonent.numberDel = "+7-123-456-78-90";
            var sw = new StringWriter();
            Console.SetOut(sw);

            abonent.showData2();

            var output = sw.ToString();
            Assert.IsTrue(output.Contains("Test FIO"));
            Assert.IsTrue(output.Contains("+7-123-456-78-90"));
        }

        [TestMethod]
        public void DiskIn_ReadsCorrectData()
        {
            //����� diskIn ������ ��������� ��������� ���, ����� �������� � ��� �� ���������� ������
            var input = "Test FIO\n+7-123-456-78-90\n2020";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(input);
            writer.Flush();
            ms.Position = 0;
            var reader = new StreamReader(ms);

            var abonent = new TelephoneAbonents();
            abonent.diskIn(reader);

            Assert.AreEqual("Test FIO", abonent.fio);
            Assert.AreEqual("+7-123-456-78-90", abonent.number);
            Assert.AreEqual(2020, abonent.year);
        }

        [TestMethod]
        public void DiskOut_WritesCorrectData()
        {
            //����� diskOut ������ ���������� ���, ����� �������� � ��� � ��������� ����� � ���������� �������
            var abonent = new TelephoneAbonents("Test FIO", "+7-123-456-78-90", 2020);
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);

            abonent.diskOut(writer);
            writer.Flush();
            ms.Position = 0;
            var output = new StreamReader(ms).ReadToEnd();

            Assert.AreEqual("Test FIO\r\n+7-123-456-78-90\r\n2020\r\n", output);
        }
    }
}