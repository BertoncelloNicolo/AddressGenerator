using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneraIP_visuale
{
    internal class AddressGenerator : IAddress
    {
        string _indrizzo; //indrizzo 
        byte[] _subnetMask; //subnetmask

        byte[] _indirizzoByte; // indirizzo in byte

        /// <summary>
        /// costruttore con inserimento della stringa dell'indirizzo 
        /// </summary>
        /// <param name="address">indica l'indirizzo</param>
        /// <exception cref="ArgumentException"></exception>
        public AddressGenerator(string indirizzo)
        {
            if (indirizzo.Length != 35)//controllo che la lunghezza sia giusta
            {
                throw new ArgumentException("Bit count must be 32, separated by a dot!");
            }
            else
            {
                _indrizzo = indirizzo;
            }
        }
        /// <summary>
        /// metodo per generare l'ipv4
        /// </summary>
        /// <returns></returns>
        public string generateIPv4()
        {
            _indirizzoByte = ConvertToByte(_indrizzo); //tramite il metodo converto il byte l'indirizzo 
            return _indirizzoByte[0] + "." + _indirizzoByte[1] + "." + _indirizzoByte[2] + "." + _indirizzoByte[3]; //e lo assegno all'otteto
        }
        /// <summary>
        /// metodo per generare subnet 
        /// </summary>
        /// <returns></returns>
        public string generateSubnet()
        {
            int cidr; //varibile per il cidr
            Random r = new Random();// numero random 
            cidr = r.Next(0, 32); //estraggo un cidr random da 1 a 32
            string subnet = SubnetBinaria(cidr); //converto il cidr in una Subnet sotto forma di binario 
            _subnetMask = ConvertToByte(subnet); //successivamente la converto in byte 
            return _subnetMask[0] + "." + _subnetMask[1] + "." + _subnetMask[2] + "." + _subnetMask[3]; // ritorno la subnet 
        }


        /// <summary>
        /// metodo per convertire in byte 
        /// </summary>
        /// <param name="address"> parametro con l'indrizzo</param>
        /// <returns></returns>
        public byte[] ConvertToByte(string indirizzo)
        {
            byte[] IndirizzoByte = new byte[4]; //ritorna l'indirizzo in byte
            int intero; //intero per 
            string bit; //string per il singolo bit 
            int convertito; //varible int che mi indica il valore convertito
            string[] byteSingolo = indirizzo.Split('.');//splitto l'indirizzo e lo assegno a bit singolo in modo da lavorare separatamente 
            for (int i = 0; i < 4; i++)
            {
                intero = 0;
                bit = byteSingolo[i];
                for (int j = 0; j < 8; j++) //for che itera gli 8 bit che si considerano in quel momento
                {
                    convertito = int.Parse(bit[j].ToString()); //converto il carattere da bit a intero
                    intero += convertito * (int)Math.Pow(2, 7 - j); //valore decimale sommato alla variabile intero
                }
                IndirizzoByte[i] = Convert.ToByte(intero); // converto in byte e inserisco nell'array
            }
            return IndirizzoByte; //ritorno l'array 
        }

        /// <summary>
        /// metodo per convertire la subnet in binario 
        /// </summary>
        /// <param name="cidr">inserimento cidr</param>
        /// <returns></returns>
        static string SubnetBinaria(int cidr)
        {
            if (cidr < 0 || cidr > 32) //controllo del cidr 
            {
                throw new ArgumentException("inserire un cidr corretto");
            }

            string subnetBin = "";

            for (int i = 0; i < cidr; i++) //scorro tante volte quanti sono i bit del cidr 
            {
                subnetBin += "1"; //aggiungo un 1 a subnet bin
            }

            for (int i = cidr; i < 32; i++) //inserisco i bit rimanenti a zero
            {
                subnetBin += "0";
            }

            return subnetBin.Insert(8, ".").Insert(17, ".").Insert(26, "."); // uso il metodo insert per inserie un punto ogni 8, 16 e 24 bit 
        }
    }
}
