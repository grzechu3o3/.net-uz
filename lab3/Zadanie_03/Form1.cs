using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_03
{
    public partial class Form1 : Form
    {
        private BigInteger p = 397; 
        private BigInteger q = 401;
        private BigInteger n, phi, eKey, dKey;

        public Form1()
        {
            InitializeComponent();
            SetupRSA();
        }

        private void SetupRSA()
        {
            n = p * q;
            phi = (p - 1) * (q - 1);
            eKey = 65537;
            dKey = ModInverse(eKey, phi);
        }

        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            try
            {
                string message = txtInput.Text;
                if (string.IsNullOrEmpty(message)) return;

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                BigInteger m = new BigInteger(messageBytes);

                if (m >= n)
                {
                    MessageBox.Show("Tekst jest za długi dla obecnego modułu N! Użyj większych liczb pierwszych.");
                    return;
                }

                BigInteger encrypted = BigInteger.ModPow(m, eKey, n);
                txtEncrypted.Text = encrypted.ToString();

                BigInteger decryptedBigInt = BigInteger.ModPow(encrypted, dKey, n);
                
                byte[] decryptedBytes = decryptedBigInt.ToByteArray();
                string result = Encoding.UTF8.GetString(decryptedBytes);
                
                lblDecrypted.Text = "Odszyfrowano: " + result;
                txtPublicKey.Text = $"Klucz publiczny (e, n): ({eKey}, {n})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private BigInteger ModInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
    }
}
