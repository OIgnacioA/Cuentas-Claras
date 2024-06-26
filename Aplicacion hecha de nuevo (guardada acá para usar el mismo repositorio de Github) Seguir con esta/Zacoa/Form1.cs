﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuentasClaras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MontoNacho2.Enabled = false;
            MontoAnto2.Enabled = false;
            label6.Enabled = false;
            label5.Enabled = false;
            MontoEnposo.ReadOnly = true;
            MontoEnposo.TextAlign = HorizontalAlignment.Right;

            Historial.ReadOnly = true;
            MontoNacho2.TextAlign = HorizontalAlignment.Right;
            MontoGastado.TextAlign = HorizontalAlignment.Right;
            MontoAnto2.TextAlign = HorizontalAlignment.Right;



            desktt  = Environment.GetFolderPath (Environment.SpecialFolder.Desktop);
            Path = desktt +  "\\zacoa.txt" ;
            EscribirBase();
            Refrescar();

            LeerBase();
            //MensajesDatos();

            if (PozoDeudaActual == null) {
                PozoDeudaActual = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Monto Inicial de Deuda", "Deuda-Punto de partida- ", "0", 200, 200);
                MontoEnposo.Text = ("-" + PozoDeudaActual);
                MontoTotal = Convert.ToInt32(MontoEnposo.Text);

                AjusteTamaño(MontoTotal, 0, 0, 0);
                
                Flagg = true;
                EscribirBase();
            }
            else {

                MontoTotalAux = CorregirSigno(PozoDeudaActual);


                MontoTotal = Convert.ToInt32(MontoTotalAux);
                MontoEnposo.Text = MontoTotalAux;
            }


          

        }

        public void ComprobacionNumerica() {

            Pass = true;

            try
            {
                int pru1;
                int pru2;
                int pru3;

                if (MontoGastado.Text != "") { pru1 = Convert.ToInt32(MontoGastado.Text); }
                if (MontoNacho2.Text != "") { pru2 = Convert.ToInt32(MontoNacho2.Text); }
                if (MontoAnto2.Text != "") { pru3 = Convert.ToInt32(MontoAnto2.Text); }


            }
            catch (Exception ex)
            {

                string mensaje = string.Format("Los datos ingresados no son correctos - Reveer. ");
                MessageBox.Show(mensaje);

                MontoGastado.Text = "";
                MontoNacho2.Text = "";
                MontoAnto2.Text = "";

                Refrescar();
                Pass = false;
            }



        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            ComprobacionNumerica();

                if ( Pass ==  true  ) { 






                if (MontoGastado.Text == "") {

                    MontoGastado.Text = Microsoft.VisualBasic.Interaction.InputBox("No ha ingresado Un Valor de Gasto", "Monto Gastado- ", "0", 200, 200);

                }

                MontoGasto = Convert.ToInt32(MontoGastado.Text);

                if (radioDeudaAgregar.Checked){

   
                    if (Full2.Checked)
                    {

                        DialogResult result = MessageBox.Show("Desea que el monto de ( " + MontoGasto + " ) se reste al Fondo?", "Warning",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            int Dato = MontoTotal;
                            MontoEnposo.Text = Convert.ToString(MontoTotal - MontoGasto);
                            MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                            string text = string.Format("El fondo se ha reducido de {0}  a  {1}", Dato, MontoTotal);
                            MessageBox.Show(text);
                            detalles = MensajeDetalles();

                        }
                        else if (result == DialogResult.No)
                        {
                        
                        }
                        else if (result == DialogResult.Cancel)
                        {
                        
                        }

                    }
                    else if (Full2.Checked == false)
                    {

                        DialogResult result = MessageBox.Show("Desea que la mitad del monto :  ( " + MontoGasto + " ),  sea reste al fondo?", "Warning",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            int Dato = MontoTotal;
                            MontoEnposo.Text = Convert.ToString(MontoTotal - (MontoGasto / 2));
                            MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                            string text = string.Format("El fondo se ha reducido de {0}  a  {1}", Dato, MontoTotal);
                            MessageBox.Show(text);
                            detalles = MensajeDetalles();
                        }
                        else if (result == DialogResult.No)
                        {
                        
                        }
                        else if (result == DialogResult.Cancel)
                        {
                        
                        }
                    }
                }

                if (RadioDeudaRestar.Checked) {

              

                    if (Full2.Checked)
                    {

                        DialogResult result = MessageBox.Show("Desea que el monto de: ( " + MontoGasto + " ), se agregue al fondo?", "Warning",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            int Dato = MontoTotal;
                            MontoEnposo.Text = Convert.ToString(MontoTotal + MontoGasto);
                            MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                            string text = string.Format("El fondo ha crecido de {0}  a  {1}", Dato, MontoTotal);
                            MessageBox.Show(text);
                            detalles = MensajeDetalles();

                        }
                        else if (result == DialogResult.No)
                        {
                       
                        }
                        else if (result == DialogResult.Cancel)
                        {
                       
                        }

                    }
                    else if (Full2.Checked == false)
                    {

                        DialogResult result = MessageBox.Show("Desea que la mitad del monto: ( " + MontoGasto + " ), se agregue al fondo?", "Warning",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            int Dato = MontoTotal;
                            MontoEnposo.Text = Convert.ToString(MontoTotal + (MontoGasto / 2));
                            MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                            string text = string.Format("El fondo ha crecido de {0}  a  {1}", Dato, MontoTotal);
                            MessageBox.Show(text);
                            detalles = MensajeDetalles();
                        }
                        else if (result == DialogResult.No)
                        {
                        
                        }
                        else if (result == DialogResult.Cancel)
                        {
                        
                        }
                    }

                }

                if (CheckAmbos.Checked){


                    MontoNacho = Convert.ToInt32(MontoNacho2.Text);
                    MontoAnto = Convert.ToInt32(MontoAnto2.Text);

                    Diferencia = CalcularDiferencia(MontoNacho, MontoAnto, MontoTotal);

                    if(MontoNacho > MontoAnto){      

                        DialogResult result = MessageBox.Show("Desea que el monto de: ( " + Diferencia + " ), se agregue al Fondo?", "Warning",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            int Dato = MontoTotal;
                            MontoEnposo.Text = Convert.ToString(MontoTotal + Diferencia);
                            MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                            string text = string.Format("El fondo ha crecido de {0}  a  {1}", Dato, MontoTotal);
                            MessageBox.Show(text);
                            detalles = MensajeDetalles();

                        }
                        else if (result == DialogResult.No)
                        {
                       
                        }
                        else if (result == DialogResult.Cancel)
                        {
                        
                        }

                    }

                    if (MontoNacho < MontoAnto)
                    {

                        DialogResult result = MessageBox.Show("Desea que el monto de: ( " + Diferencia + " ), sea restado del fondo?", "Warning",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            int Dato = MontoTotal;
                            MontoEnposo.Text = Convert.ToString(MontoTotal - Diferencia);
                            MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                            string text = string.Format("El fondo sehareducido de: {0}  a  {1}", Dato, MontoTotal);
                            MessageBox.Show(text);
                            detalles = MensajeDetalles();

                        }
                        else if (result == DialogResult.No)
                        {
                       
                        }
                        else if (result == DialogResult.Cancel)
                        {
                       
                        }

                    }

                }



                AjusteTamaño(MontoTotal, MontoNacho, MontoAnto, MontoGasto);

                //MontoParcial = CalcularDiferencia(MontoNacho, MontoAnto, MontoTotal);

                EscribirBase();

                LeerBase();

                Refrescar();
          

            }
        }




        public void EscribirBase()
        {
            using (StreamWriter sw = new StreamWriter(Path, true)) {

                try
                {

                    fechaTransaccion = fecha.Value.Date.ToString(); // Solo promera vez

                    if (Flagg == true)
                    {
                        detalles = string.Format("Inicio de sesion con {0} del dìa {1}", MontoTotalS, fechaTransaccion);

                        DATA = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoAntoS, MontoNachoS, MontoGastoS, fechaTransaccion, detalles);
                        AjusteTamaño(DATA);


                        sw.WriteLine(DATA + System.Environment.NewLine);
                        sw.Close();

                    }

                    if (radioDeudaAgregar.Checked)
                    {

                        DATA = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoAntoS, MontoNachoS, MontoGastoS, fechaTransaccion, detalles);
                        AjusteTamaño(DATA);

                        sw.WriteLine(DATA + System.Environment.NewLine);
                        sw.Close();

                    }
                    else if (RadioDeudaRestar.Checked)
                    {

                        DATA = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoAntoS, MontoNachoS, MontoGastoS, fechaTransaccion, detalles);
                        AjusteTamaño(DATA);

                        sw.WriteLine(DATA + System.Environment.NewLine);
                        sw.Close();
                    }


                    if (CheckAmbos.Checked)
                    {
                        DATA = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoAntoS, MontoNachoS, MontoGastoS, fechaTransaccion, detalles);
                        AjusteTamaño(DATA);

                        sw.WriteLine(DATA + System.Environment.NewLine);
                        sw.Close();

                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }

            }
            LeerBase();

        }

        public void LeerBase()
        {
            Historial.Text = String.Empty;
            DataEnBase = String.Empty;
            TodaDataEnBase = String.Empty;
            string AuxTransaccion = ""; ;

            using (StreamReader sr = new StreamReader(Path))
            { 

                try{
                
                    line = sr.ReadLine();

                    while (line != null)
                    {
                        if (line != "")
                        {
                            PozoDeudaActual = line.Substring(0, 5);


                            string poso = line.Substring(0, 5);
                            string posoAux = CorregirSigno(poso);
                            string Anto = line.Substring(6, 5);
                            string Nacho = line.Substring(12, 5);
                            string Gasto = line.Substring(18, 5);
                            string Transaccion = line.Substring(24, 17);
                            string Detalles = line.Substring(42, 108);



                            VerMaximoDeBarra(Int32.Parse(posoAux)); 


                            if (Flagg == true){

                                DataEnBase = string.Format("El poso comienza en : " + posoAux + "$" + "\r\n");

                                Flagg = false; 

                            } else { 

                                DataEnBase = string.Format("El ultimo poso fue de: " + posoAux + "$" + "\r\n" + "El gasto de Nacho fue de: " + Nacho + "$" + "\r\n" + "El gasto de anto fue de:" + Anto + "$" + "\r\n" + "El gasto total fue de: " + Gasto + "$" + "\r\n" + "La fecha fue: " + Transaccion + "\r\n" + "Detalle: " + Detalles + "$" + "\r\n" + "\r\n");
                           
                            
                            }


                            if (Transaccion != AuxTransaccion)
                            {
                                TodaDataEnBase += "------------------------------- Archivo Dia: " + Transaccion + " -----" + "\r\n";
                            }

                            AuxTransaccion = Transaccion;

                            TodaDataEnBase += DataEnBase;

                            contenido = CrearHTML(poso, Nacho, Anto, Gasto, Transaccion, Detalles);

                            line = sr.ReadLine();
                        }
                        else
                        {
                            line = sr.ReadLine();
                        }
                    }

                    Historial.Text = DataEnBase;
                    sr.Close();
                    //Console.ReadLine();
                }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            
            }

        }


        public void VerMaximoDeBarra(int poso) {

            if (poso < 0 ) { maximodeBarra = poso * -1;}
            if (poso >= 0) { maximodeBarra = 100; barra.Value = 100;}

        }



        public void AjusteTamaño(string data)
        {
            data += "|";
            int var1 = data.Length;
            if (var1 < 150)
            {

                while (var1 != 150)
                {
                    data += "-";
                    var1++;
                }
            }

            DATA = data;
        }

        public String CorregirSigno(string dato) {

            int cont = 0;
            bool flag = false; 


            for (int i = 0; i < dato.Length; i++) {
                char letra = dato[i];

                if ((letra == '0') && (flag == false)) { 
                   cont++;  

                }else {

                    flag = true;

                }
                
            }

            if (flag == false) {

                MontoTotalAux = "0";

            } else {

                MontoTotalAux = dato.Substring(cont, (dato.Length - cont));

            }

          


            return MontoTotalAux;
        }

        private void GenerarArchivo_Click(object sender, EventArgs e)
        {
            html = string.Empty;
            contenido = string.Empty;

            LeerBase();

            string patth = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string name = string.Format("{0}\\archivo.html",patth);

            StreamWriter sw = new System.IO.StreamWriter(name);


            htmlHead = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title> Document </title><style>body {background-image: url('htt";


            htmlHead += "ps://www.sacoacard.com/uploads/fotos/22/foto_22.jpg');width: 100%;height: 100%;position: absolute;}</style></head><body><Caption> Planilla de Gastos: (Zacoa) </caption><br><br><table border =\"3\"><thead style = 'background: rgb(224, 165, 106);; border: 1px solid rgba(200, 100, 0, 0.3);'><tr><th>Fecha</th><th> Poso </th><th> Gasto de Nacho </th><th> Gasto de Anto </th><th> Gasto Total </th><th> Detalles </th></tr></thead><tbody style='background: rgb(189, 207, 241); border: 2px solid rgba(17, 10, 4, 0.3);'>";


            htmlFoot = string.Format("</tbody></table></body></html> ");



            sw.Write(htmlHead + contenido + htmlFoot);
            sw.WriteLine();
            sw.Close();

            contenido = string.Empty;

            string text = string.Format("Se hagenerado el Archivo HTML en escritorio");
            MessageBox.Show(text);
        }

        private string CrearHTML(string posso, string Naccho, string Antto, string Gassto, string Transsaccion, string Dettalles) {

            html += string.Format("<tr><th><font color ='blue'> {0} </th></font><td><center>{1}", Transsaccion, posso);
            html += string.Format("</center></td><td><center>{0}", Naccho);
            html += string.Format("</center></td><td><center>{0}", Antto);
            html += string.Format("</center></td><td><center>{0}", Gassto);
            html += string.Format("</center></td><td><center>{0} </center></td></tr>", Dettalles);

            return  html;
        }




        private int CalcularDiferencia(int monN, int monA, int MonT) {

            int Dif = 0;

            if (monN > monA) {

                diff = monN - monA;
                Dif = (diff / 2);

                mensaje(Dif, "Anto", "Nacho");
            } else if (monN < monA) {

                diff = monA - monN;
                Dif = (diff / 2);

                mensaje(Dif, "Nacho", "Anto");
            }

            return Dif;
        }

        public void AjusteTamaño(int poso, int nacho, int anto, int gasto) {

            Lista1 = new int[4] { poso, nacho, anto, gasto };
            Lista2 = new string[4];

            for (int i = 0; i < 4; i++) {
                Lista2[i] = Convert.ToString(Lista1[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                string var2 = Lista2[i];
                string var3 = "";

                if (var2.Length < 5) {

                    while (var2.Length < 5) {
                        var3 = "0";
                        var2 = var3 + var2;

                    }
                   
                    Lista2[i] = var2;
                }
                else { 
                 Lista2[i] = var2;
                }

            }

            for (int i = 0; i < 4; i++) { //usar una variables de nombre similarpero en String en vez de INt esta relacionado a la dificultad de uso de una u otra variabe en las diferentes partes del código, 

                Lista2[i]= Lista2[i];
               
                MontoTotalS = Lista2[0];
                MontoNachoS = Lista2[1];
                MontoAntoS = Lista2[2];
                MontoGastoS = Lista2[3];
            }
        }

        public void mensaje(int monto, string nom1, string nom2)
        {
            if (radioCuenta.Checked)
            {
                string text = string.Format("{0} debe pagar a {1} un total de {2} pesukos", nom1, nom2, monto);
                MessageBox.Show(text);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            LeerBase(); 
            Historial.Text = TodaDataEnBase;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAmbos.Checked)
            {
                checkNacho.Checked = false;
                checkAnto.Checked = false;
                Full2.Checked = false;

                MontoNacho2.Enabled = true;
                MontoAnto2.Enabled = true;
                label6.Enabled = true;
                label5.Enabled = true;
                radioCuenta.Enabled = true;
                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                Full2.Enabled = false;           
                checkHalf.Enabled = false;
                Guardar.Enabled = true;

                
                radioCuenta.Enabled = true;

            }
            else
            {
             
                MontoNacho2.Enabled = false;
                MontoAnto2.Enabled = false;
                label6.Enabled = false;
                label5.Enabled = false;
                radioCuenta.Enabled = false;


                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                Full2.Enabled = false;
                checkHalf.Enabled = false;

                Guardar.Enabled = false;

            }
            

        }

        private void checkAnto_CheckedChanged(object sender, EventArgs e)
        {

            if (checkAnto.Checked)
            {
                checkNacho.Checked = false;
                CheckAmbos.Checked = false;
                checkHalf.Checked = false;
                Full2.Checked = false;
                radioCuenta.Checked = false;
                radioCuenta.Enabled = false;
                radioDeudaAgregar.Enabled = true;
                RadioDeudaRestar.Enabled = false;

                Guardar.Enabled = false;

                radioDeudaAgregar.Focus();              
            }
            else {

                Guardar.Enabled = false;
                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                checkHalf.Enabled = false;
                Full2.Enabled = false;
                radioCuenta.Checked = false;
                radioCuenta.Enabled = false;


                radioDeudaAgregar.Checked = false;
                RadioDeudaRestar.Checked = false;
                checkHalf.Checked = false;
                Full2.Checked = false;
            }

        }

        private void checkBoxNacho_CheckedChanged(object sender, EventArgs e)
        {

            if (checkNacho.Checked)
            {
                checkAnto.Checked = false;
                CheckAmbos.Checked = false;
                checkHalf.Checked = false;
                Full2.Checked = false;
                radioCuenta.Checked = false;
                radioCuenta.Enabled = false;
                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = true;

                Guardar.Enabled = false;

                RadioDeudaRestar.Focus();

            }
            else if (checkNacho.Checked == false) {

                Guardar.Enabled = false;
                radioDeudaAgregar.Enabled = false;   
                RadioDeudaRestar.Enabled = false;
                checkHalf.Enabled = false;
                Full2.Enabled = false;
                radioCuenta.Checked = false;
                radioCuenta.Enabled = false;


                radioDeudaAgregar.Checked = false;
                RadioDeudaRestar.Checked = false;
                checkHalf.Checked = false;
                Full2.Checked = false;
  
            }
 

        }
       
        

        public void Refrescar() {
          
            radioDeudaAgregar.Enabled = false;

            checkHalf.Enabled = false;
            Full2.Enabled = false;

            RadioDeudaRestar.Enabled = false;
            Guardar.Enabled = false;
            radioDeudaAgregar.Checked = false;
            RadioDeudaRestar.Checked = false;
            CheckAmbos.Checked = false;
            checkAnto.Checked = false;
            checkNacho.Checked = false;
            checkHalf.Checked = false;
            radioCuenta.Checked = false;
            radioCuenta.Enabled = false;
            MontoGastado.Text = "";
          


        }

        public void MensajesDatos()
        {

            string Gasto = "";


            DialogResult result = MessageBox.Show("Nacho realizó una compra a compartir?", "Warning",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                Gasto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Monto Invertido Total", "Monto gastado", "0", 100, 0);


                DialogResult result2 = MessageBox.Show("Desea sumar la parte de Nacho la deuda?", "Warning",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result2 == DialogResult.Yes)
                {
                    int Dato = MontoTotal;
                    MontoEnposo.Text = Convert.ToString(MontoTotal - MontoGasto);
                    string text = string.Format("La deuda ha aumentado de {0} a {1}", Dato, MontoTotal);
                    MessageBox.Show(text);

                }
                else if (result2 == DialogResult.No)
                {
                    DialogResult result3 = MessageBox.Show("Desea restar la inversion de Nacho a la deuda?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result3 == DialogResult.Yes)
                    {
                        int Dato = MontoTotal;
                        MontoEnposo.Text = Convert.ToString(MontoTotal - MontoGasto);
                        string text = string.Format("La deuda ha aumentado de {0} a {1}", Dato, MontoTotal);
                        MessageBox.Show(text);

                    }
                    else if (result3 == DialogResult.No)
                    {
                        //code for No
                    }
                    else if (result3 == DialogResult.Cancel)
                    {
                        //code for Cancel
                    }
                }
                else if (result2 == DialogResult.Cancel)
                {
                    //code for Cancel
                }

            }
            else if (result == DialogResult.No)
            {
                //code for No
            }
            else if (result == DialogResult.Cancel)
            {
                //code for Cancel
            }



        }

        public string MensajeDetalles()
        {
            string texto;
            string textoMemoria = "";

            texto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese detalles:palabras clave (hasta 80 caracteres)", "Detalles de gasto ", "0", 200, 200);

            while (texto.Length > 80)
            {
                textoMemoria = texto;
                string text = string.Format("La cantidad de caracteres no debe ser mayor a 80");
                MessageBox.Show(text);
                texto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese detalles:palabras clave (hasta 80 caracteres)", "Detalles de gasto ", textoMemoria, 500, 500);

            }

            return texto;
        }

        private void Full2_CheckedChanged(object sender, EventArgs e)
        {
            if (Full2.Checked)
            {
                checkHalf.Checked = false;
                Guardar.Enabled = true;
                Guardar.Focus();
            }
            else {
                //checkHalf.Checked = true;
                Guardar.Enabled = false;
            }

        }

        private void checkHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHalf.Checked)
            {
                Full2.Checked = false;
                Guardar.Enabled = true;
                Guardar.Focus();
            }
            else
            {
                //Full2.Checked = true;
                Guardar.Enabled = false;
            }
        
        }

        private void MontoNacho2_TextChanged(object sender, EventArgs e)
        {

            ComprobacionNumerica();

            int var1;
            int var2;


            if (MontoGastado.Text != "")
            {

                if (MontoNacho2.Text == "")
                {
                    var1 = Convert.ToInt32("0");
                    if (MontoGastado.Text == "")
                    {
                        MontoGastado.Text = "0";
                    }

                    try { 
                    var2 = Convert.ToInt32(MontoGastado.Text);
                    MontoAnto2.Text = Convert.ToString(var2 - var1);
                    }
                    catch (Exception ex) { }

                    

                }
                else
                {

                    var1 = Convert.ToInt32(MontoNacho2.Text);
                    if (MontoGastado.Text == "")
                    {
                        MontoGastado.Text = "0";
                    }

                    try
                    {
                        var2 = Convert.ToInt32(MontoGastado.Text);
                    MontoAnto2.Text = Convert.ToString(var2 - var1);
                    }
                    catch (Exception ex) { }


                }


            }
        }

        private void MontoAnto2_TextChanged(object sender, EventArgs e)
        {

            ComprobacionNumerica();

            
            int var1;
            int var2;
        if (MontoGastado.Text != "") { 
                if (MontoAnto2.Text == "")
                {
                    var1 = Convert.ToInt32("0");


                    if (MontoGastado.Text == "")
                    {
                        MontoGastado.Text = "0";
                    }

                    var2 = Convert.ToInt32(MontoGastado.Text);
                    MontoNacho2.Text = Convert.ToString(var2 - var1);
                }
                else
                {

                    var1 = Convert.ToInt32(MontoAnto2.Text);


                    if (MontoGastado.Text == "")
                    {
                        MontoGastado.Text = "0";
                    }
                    var2 = Convert.ToInt32(MontoGastado.Text);
                    MontoNacho2.Text = Convert.ToString(var2 - var1);

                }

            }
        }

        private void MontoGastado_TextChanged(object sender, EventArgs e)
        {

            ComprobacionNumerica();

            MontoNacho2.Text = "";
                MontoAnto2.Text = "";

            if (MontoGastado.Text == "0")
            {

                MontoGastado.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
  
            if (radioDeudaAgregar.Checked) {      

                Full2.Enabled = true;
                checkHalf.Enabled = true;
            }
        }

        private void RadioDeudaRestar_CheckedChanged(object sender, EventArgs e)
        {

            if (RadioDeudaRestar.Checked)
            {
                Full2.Enabled = true;
                checkHalf.Enabled = true;
            }
        }

        #region
        private void textBox2_TextChanged(object sender, EventArgs e){
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        #endregion

        private int diff;
        private int Diferencia;
        private int[] Lista1;
        private int MontoTotal;
        private int MontoParcial;
        private int MontoNacho;
        private int MontoAnto;
        private int MontoGasto;
        private String Path;
        private String detalles;
        private String line;
        private String fechaTransaccion;
        private string DataEnBase;
        private String PozoDeudaActual;
        private String[] Lista2;
        private bool Flagg;
        private string MontoTotalS;
        private string MontoNachoS;
        private string MontoAntoS;
        private string MontoGastoS;
        private string DATA;
        private string TodaDataEnBase;
        private string MontoTotalAux;
        private string contenido;
        private string html;
        private string htmlFull;
        private string htmlHead;
        private string htmlFoot;
        private string desktt;
        private int maximodeBarra;
        private bool Pass; 



    }


}
