using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetirabanıTönetimOdev1
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            string dosyayolu ="öğrenciler.dat";
            using (StreamWriter yazici = File.AppendText(dosyayolu))
            {
                yazici.WriteLine(kayitlar);
            }


            while (true)
            {
                Console.WriteLine("Lütfen bir işlem seçiniz:");
                Console.WriteLine("1 - Kayıt Ekle");
                Console.WriteLine("2 - Kayıtları Listele");
                Console.WriteLine("3 - Kayıt Ara");
                Console.WriteLine("4 - Kayıt Düzenle");
                Console.WriteLine("5 - Çıkış");

                string secim = Console.ReadLine();
                Console.Clear();

                switch (secim)
                {
                    case "1":
                        KayitEkle(dosyayolu);
                        break;
                    case "2":
                        KayitListele(dosyayolu);
                        break;
                    case "3":
                        KayitAra(dosyayolu);
                        break;
                    case "4":
                        KayitDuzenle(dosyayolu);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen tekrar deneyin.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void KayitEkle(string dosyayolu)
        {
            Console.WriteLine("Kayıt eklemek için aşağıdaki bilgileri giriniz:");

            Console.Write("Ad: ");
            string ad = Console.ReadLine();

            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();

            Console.Write("Numara: ");
            string numara = Console.ReadLine();

            Console.Write("Bölüm: ");
            string bolum = Console.ReadLine();

            Console.Write("Cinsiyet: ");
            string cinsiyet = Console.ReadLine();

            Console.Write("Doğum Yeri: ");
            string dogumYeri = Console.ReadLine();

            Console.Write("Yaş: ");
            string yas = Console.ReadLine();

            Console.Write("Telefon Numarası: ");
            string telefon = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(dosyayolu, true))
            {
                sw.WriteLine($"{ad},{soyad},{numara},{bolum},{cinsiyet},{dogumYeri},{yas},{telefon}");
            }

            Console.WriteLine("Kayıt başarıyla eklendi.");
        }

        static void KayitListele(string dosyayolu)
        {
            Console.WriteLine("Kayıtlar:");

            

            Console.WriteLine("Ad\tSoyad\tNumara\tBölüm\tCinsiyet\tDoğum Yeri\tYaş\tTelefon");
            string[] kayitlar = File.ReadAllLines(dosyayolu);

            foreach (string kayit in kayitlar)
            {
                string[] bilgiler = kayit.Split(',');

                Console.WriteLine($"{bilgiler[0]}\t{bilgiler[1]}\t{bilgiler[2]}\t{bilgiler[3]}\t{bilgiler[4]}\t{bilgiler[5]}\t{bilgiler[6]}\t{bilgiler[7]}");
            }

            Console.WriteLine();
            Console.WriteLine("Listeleme tamamlandı.");
        }

        static void KayitAra(string dosyayolu)
        {
            Console.WriteLine("Arama kriterlerini giriniz:");

            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();

            Console.Write("Numara: ");
            string numara = Console.ReadLine();

            Console.Write("Bölüm: ");
            string bolum = Console.ReadLine();

            Console.Write("Cinsiyet: ");
            string cinsiyet = Console.ReadLine();

            Console.Write("Doğum Yeri: ");
            string dogumYeri = Console.ReadLine();

            Console.Write("Yaş: ");
            string yas = Console.ReadLine();

            Console.Write("Telefon Numarası: ");
            string telefon = Console.ReadLine();

            string[] kayitlar = File.ReadAllLines(dosyayolu);

            bool bulundu = false;

            foreach (string kayit in kayitlar)
            {
                string[] bilgiler = kayit.Split(',');

                if ((string.IsNullOrEmpty(ad) || bilgiler[0].Equals(ad, StringComparison.OrdinalIgnoreCase))
                    && (string.IsNullOrEmpty(soyad) || bilgiler[1].Equals(soyad, StringComparison.OrdinalIgnoreCase))
                    && (string.IsNullOrEmpty(numara) || bilgiler[2].Equals(numara, StringComparison.OrdinalIgnoreCase))
                    && (string.IsNullOrEmpty(bolum) || bilgiler[3].Equals(bolum, StringComparison.OrdinalIgnoreCase))
                    && (string.IsNullOrEmpty(cinsiyet) || bilgiler[4].Equals(cinsiyet, StringComparison.OrdinalIgnoreCase))
                    && (string.IsNullOrEmpty(dogumYeri) || bilgiler[5].Equals(dogumYeri, StringComparison.OrdinalIgnoreCase))
                    && (string.IsNullOrEmpty(yas) || bilgiler[6].Equals(yas, StringComparison.OrdinalIgnoreCase))
                    && (string.IsNullOrEmpty(telefon) || bilgiler[7].Equals(telefon, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"{bilgiler[0]}\t{bilgiler[1]}\t{bilgiler[2]}\t{bilgiler[3]}\t{bilgiler[4]}\t{bilgiler[5]}\t{bilgiler[6]}\t{bilgiler[7]}");
                    bulundu = true;
                }
            }

            if (!bulundu)
            {
                Console.WriteLine("Aranan öğrenci bulunamadı.");
            }
        }

        static void KayitDuzenle(string dosyayolu)
        {
            Console.Write("Düzenlemek istediğiniz öğrencinin numarasını giriniz: ");
            string numara = Console.ReadLine();

            string[] kayitlar = File.ReadAllLines(dosyayolu);
            bool bulundu = false;

            for (int i = 0; i < kayitlar.Length; i++)
            {
                string[] bilgiler = kayitlar[i].Split(',');

                if (bilgiler[2].Equals(numara, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{bilgiler[0]}\t{bilgiler[1]}\t{bilgiler[2]}\t{bilgiler[3]}\t{bilgiler[4]}\t{bilgiler[5]}\t{bilgiler[6]}\t{bilgiler[7]}");
                    Console.WriteLine("Lütfen düzenlemek istediğiniz bilgiyi giriniz (değiştirmek istemediğiniz bilgi için önce Enter'a basınız):");

                    Console.Write("Ad: ");
                    string ad = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ad))
                    {
                        bilgiler[0] = ad;
                    }

                    Console.Write("Soyad: ");
                    string soyad = Console.ReadLine();
                    if (!string.IsNullOrEmpty(soyad))
                    {
                        bilgiler[1] = soyad;
                    }

                    Console.Write("Numara: ");
                    string yeniNumara = Console.ReadLine();
                    if (!string.IsNullOrEmpty(yeniNumara))
                    {
                        bilgiler[2] = yeniNumara;
                    }

                    Console.Write("Bölüm: ");
                    string bolum = Console.ReadLine();
                    if (!string.IsNullOrEmpty(bolum))
                    {
                        bilgiler[3] = bolum;
                    }

                    Console.Write("Cinsiyet: ");
                    string cinsiyet = Console.ReadLine();
                    if (!string.IsNullOrEmpty(cinsiyet))
                    {
                        bilgiler[4] = cinsiyet;
                    }

                    Console.Write("Doğum Yeri: ");
                    string dogumYeri = Console.ReadLine();
                    if (!string.IsNullOrEmpty(dogumYeri))
                    {
                        bilgiler[5] = dogumYeri;
                    }

                    Console.Write("Yaş: ");
                    string yas = Console.ReadLine();
                    if (!string.IsNullOrEmpty(yas))
                    {
                        bilgiler[6] = yas;
                    }

                    Console.Write("Telefon Numarası: ");
                    string telefon = Console.ReadLine();
                    if (!string.IsNullOrEmpty(telefon))
                    {
                        bilgiler[7] = telefon;
                    }

                    kayitlar[i] = string.Join(",", bilgiler);
                    bulundu = true;
                    break;
                }
            }

            if (bulundu)
            {
                File.WriteAllLines(dosyayolu, kayitlar);
                Console.WriteLine("Kayıt başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Öğrenci bulunamadı.");
            }
        }   
    }
}
