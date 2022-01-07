using System;
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
            Path = "BaseDeDatos.txt";
            Guardar.Enabled = false;

            radioDeudaAgregar.Enabled = false;
            RadioDeudaRestar.Enabled = false;
            Full2.Enabled = false;


            LeerBase();
            //MensajesDatos();

            if (PozoDeudaActual == null) {
                PozoDeudaActual = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Monto Inicial de Deuda", "Deuda-Punto de partida- ", "0", 200, 200);
                MontoEnposo.Text = ("-" + PozoDeudaActual);
                MontoTotal = Convert.ToInt32(MontoEnposo.Text);

                AjusteTamaño(MontoTotal, 0, 0, 0);
                detalles = "Inicio de sesion---";
                EscribirBase();
                Flagg = true; 
               
            }else {
                MontoEnposo.Text =  PozoDeudaActual;
            }

            MontoTotal = Convert.ToInt32(MontoEnposo.Text);

        }



        private void Guardar_Click(object sender, EventArgs e)
        {

            MontoGasto = Convert.ToInt32(MontoGastado.Text);

            if (radioDeudaAgregar.Checked){

   
                if (Full2.Checked)
                {

                    DialogResult result = MessageBox.Show("Desea que el monto de ( " + MontoGasto + " ) sea Agregada a la deuda?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int Dato = MontoTotal;
                        MontoEnposo.Text = Convert.ToString(MontoTotal - MontoGasto);
                        MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                        string text = string.Format("La deuda ha aumentado de {0}  a  {1}", Dato, MontoTotal);
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

                    DialogResult result = MessageBox.Show("Desea que la mitad del monto ( " + MontoGasto + " ) sea agregada a la deuda?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int Dato = MontoTotal;
                        MontoEnposo.Text = Convert.ToString(MontoTotal - (MontoGasto / 2));
                        MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                        string text = string.Format("La deuda ha aumentado de {0}  a  {1}", Dato, MontoTotal);
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

                    DialogResult result = MessageBox.Show("Desea que el monto de ( " + MontoGasto + " ) sea restada de la deuda?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int Dato = MontoTotal;
                        MontoEnposo.Text = Convert.ToString(MontoTotal + MontoGasto);
                        MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                        string text = string.Format("La deuda se ha reducido de {0}  a  {1}", Dato, MontoTotal);
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

                    DialogResult result = MessageBox.Show("Desea que la mitad del monto ( " + MontoGasto + " ) sea restada de la deuda?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int Dato = MontoTotal;
                        MontoEnposo.Text = Convert.ToString(MontoTotal + (MontoGasto / 2));
                        MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                        string text = string.Format("La deuda disminuido de {0}  a  {1}", Dato, MontoTotal);
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

                    DialogResult result = MessageBox.Show("Desea que el monto de ( " + Diferencia + " ) sea restado a la deuda?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int Dato = MontoTotal;
                        MontoEnposo.Text = Convert.ToString(MontoTotal + Diferencia);
                        MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                        string text = string.Format("La deuda ha disminuido de {0}  a  {1}", Dato, MontoTotal);
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

                    DialogResult result = MessageBox.Show("Desea que el monto de ( " + Diferencia + " ) sea agregado a la deuda?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int Dato = MontoTotal;
                        MontoEnposo.Text = Convert.ToString(MontoTotal + Diferencia);
                        MontoTotal = Convert.ToInt32(MontoEnposo.Text);
                        string text = string.Format("La deuda ha aumentado de {0}  a  {1}", Dato, MontoTotal);
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

            radioDeudaAgregar.Enabled = true;
            RadioDeudaRestar.Enabled = true;
            Full2.Enabled = true;

        }

        public void EscribirBase()
        {
            StreamWriter sw = new StreamWriter(Path, true);
            
            try
            {

                fechaTransaccion = fecha.Value.Date.ToString();

                if (radioDeudaAgregar.Checked)
                {

                    DATA = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoGastoS, MontoAntoS, MontoGastoS, fechaTransaccion, detalles);
                    AjusteTamaño(DATA);
                    //sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoNachoS, MontoAntoS, MontoGastoS, fechaTransaccion, detalles + System.Environment.NewLine);

                    sw.WriteLine(DATA + System.Environment.NewLine);
                    sw.Close();

                }
                else if (RadioDeudaRestar.Checked)
                {

                    DATA = string.Format("{0}|{1}|{2}|{3}", MontoTotalS, MontoGastoS, fechaTransaccion, detalles);
                    AjusteTamaño(DATA);
                    // sw.WriteLine("{0}|{1}|{2}|{3}", MontoTotalS, MontoGastoS, fechaTransaccion, detalles + System.Environment.NewLine);
                   
                    sw.WriteLine(DATA + System.Environment.NewLine);
                    sw.Close();
                }

                if ((radioDeudaAgregar.Checked) && (Flagg == true))
                {
                    DATA = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoGastoS, MontoAntoS, MontoGastoS, fechaTransaccion, detalles);
                    AjusteTamaño(DATA);
                    //sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoNachoS, MontoAntoS, MontoGastoS, fechaTransaccion, detalles + System.Environment.NewLine);
                   
                    sw.WriteLine(DATA + System.Environment.NewLine);
                    sw.Close();

                    Flagg = false;

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

            LeerBase();

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

            for (int i = 0; i < 4; i++) {

                Lista2[i]= Lista2[i];
               
                MontoTotalS = Lista2[0];
                MontoNachoS = Lista2[1];
                MontoAntoS = Lista2[2];
                MontoGastoS = Lista2[3];
            }
        }

        public void AjusteTamaño(string data)
        {
            int var1 = data.Length;
            if (var1 < 100) {

                int var2 = 100 - var1;
                data += "|";

                while (var2 != 100) {
                    data += "-";
                    var2++;
                }
            }

            DATA = data;
        }

        public void mensaje(int monto, string nom1, string nom2)
        {
            if (radioCuenta.Checked)
            {
                string text = string.Format("{0} debe pagar a {1} un total de {3} pesukos", monto, nom1, nom2);
                MessageBox.Show(text);
            }

        }

        public void LeerBase()
        {
            Historial.Text = String.Empty;
            DataEnBase = String.Empty;
            try
            {
                StreamReader sr = new StreamReader(Path);
                line = sr.ReadLine();

                while (line != null)
                {
                    if (line != "")
                    {
                        PozoDeudaActual = line.Substring(0, 5);


                        string poso = line.Substring(0, 5);
                        string Nacho = line.Substring(6, 5);
                        string Anto = line.Substring(12, 5);
                        string Gasto = line.Substring(18, 5);
                        string Transaccion = line.Substring(21, 5);
                        string Detalles = "";// line.Substring(26, 100);



                        DataEnBase = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", poso, Nacho, Anto, Gasto, Transaccion, Detalles ); 
                        line = sr.ReadLine();
                    }
                    else
                    {
                        line = sr.ReadLine();
                    }
                }

                Historial.Text = DataEnBase;
                sr.Close();
                Console.ReadLine();
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




        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAmbos.Checked)
            {
                checkNacho.Checked = false;
                checkAnto.Checked = false;
                MontoNacho2.Enabled = true;
                MontoAnto2.Enabled = true;
                label6.Enabled = true;
                label5.Enabled = true;
                radioCuenta.Enabled = true;


                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                Full2.Enabled = false;

                Guardar.Enabled = true;
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

                Guardar.Enabled = false;

            }
            

        }

        private void checkAnto_CheckedChanged(object sender, EventArgs e)
        {

            if (checkAnto.Checked)
            {
                checkNacho.Checked = false;
                CheckAmbos.Checked = false;
               

                radioDeudaAgregar.Enabled = true;
                RadioDeudaRestar.Enabled = true;
                Full2.Enabled = true;

            }
            else {
                Guardar.Enabled = false;
                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                Full2.Enabled = false;
            }

        }

        private void checkBoxNacho_CheckedChanged(object sender, EventArgs e)
        {

            if (checkNacho.Checked)
            {
                CheckAmbos.Checked = false;
                checkAnto.Checked = false;
               

                radioDeudaAgregar.Enabled = true;
                RadioDeudaRestar.Enabled = true;
                Full2.Enabled = true;
            }
            else {
                Guardar.Enabled = false;
                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                Full2.Enabled = false;
            }
 

        }

        #region
        private void textBox2_TextChanged(object sender, EventArgs e){
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


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

        public string MensajeDetalles() {
            string texto;
            string textoMemoria = "";

           texto =  Microsoft.VisualBasic.Interaction.InputBox("Ingrese detalles:palabras clave (hasta 30 caracteres)", "Detalles de gasto ", "0", 200, 200);

            while (texto.Length > 30) {
                textoMemoria = texto;
                string text = string.Format("La cantidad de caracteres no debe ser mayor a 30");
                MessageBox.Show(text);
                texto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese detalles:palabras clave (hasta 10 caracteres)", "Detalles de gasto ",textoMemoria, 500, 500);

            }

            return texto;
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

     
    }


    /*001000 | 1111 | Fecha:4 / 1 / 2022 00:00:00

    002000 | 2222 | Fecha:4 / 1 / 2022 00:00:00

    003000 | 3333 | Fecha:4 / 1 / 2022 00:00:00

    004000 | 4444 | Fecha:4 / 1 / 2022 00:00:00*/

}
