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

            Refrescar();

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

                MontoTotalAux = CorregirSigno(PozoDeudaActual);

                MontoTotal = Convert.ToInt32(MontoTotalAux);
                MontoEnposo.Text = MontoTotalAux;
            }


          

        }



        private void Guardar_Click(object sender, EventArgs e)
        {

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

                    sw.WriteLine(DATA + System.Environment.NewLine);
                    sw.Close();

                }
                else if (RadioDeudaRestar.Checked)
                {

                    DATA = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MontoTotalS, MontoGastoS,"00000", "00000", fechaTransaccion, detalles);
                    AjusteTamaño(DATA);
                   
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

        public void LeerBase()
        {
            Historial.Text = String.Empty;
            DataEnBase = String.Empty;
            TodaDataEnBase = String.Empty;
            string AuxTransaccion = ""; ;
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
                        string posoAux = CorregirSigno(poso);
                        string Nacho = line.Substring(6, 5);
                        string Anto = line.Substring(12, 5);
                        string Gasto = line.Substring(18, 5);
                        string Transaccion = line.Substring(24, 17);
                        string Detalles = line.Substring(42, 108);



                        DataEnBase = string.Format("El ultimo poso fue de: " + posoAux + "$" + "\r\n" + "El gasto de Nacho fue de: " + Nacho + "$" + "\r\n" + "El gasto de anto fue de:" + Anto + "$" + "\r\n" + "El gasto total fue de: " + Gasto + "$" + "\r\n" + "La fecha fue: " + Transaccion + "\r\n" + "Detalle: " + Detalles + "$" + "\r\n" + "\r\n");

                        if (Transaccion != AuxTransaccion)
                        {
                            TodaDataEnBase += "------------------------------- Archivo Dia: " + Transaccion + " -----" + "\r\n";
                        }

                        AuxTransaccion = Transaccion;

                        TodaDataEnBase += DataEnBase;

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

            MontoTotalAux = dato.Substring(cont, (dato.Length - cont));

            return MontoTotalAux;
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

        public void mensaje(int monto, string nom1, string nom2)
        {
            if (radioCuenta.Checked)
            {
                string text = string.Format("{0} debe pagar a {1} un total de {3} pesukos", monto, nom1, nom2);
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
                checkHalf.Checked = true;
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
                

                radioDeudaAgregar.Enabled = true;
                RadioDeudaRestar.Enabled = true;
                Full2.Enabled = true;
                checkHalf.Enabled = true;

            }
            else {
                Guardar.Enabled = false;
                radioDeudaAgregar.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                Full2.Enabled = false;
                checkHalf.Enabled = false;

                radioDeudaAgregar.Checked = false;
                RadioDeudaRestar.Checked = false;
            }

        }

        private void checkBoxNacho_CheckedChanged(object sender, EventArgs e)
        {

            if (checkNacho.Checked)
            {
                CheckAmbos.Checked = false;
                checkAnto.Checked = false;
               

                radioDeudaAgregar.Enabled = true;
                checkHalf.Enabled = true;
                RadioDeudaRestar.Enabled = true;
                Full2.Enabled = true;
            }
            else {
                Guardar.Enabled = false;
                radioDeudaAgregar.Enabled = false;
                checkHalf.Enabled = false;
                RadioDeudaRestar.Enabled = false;
                Full2.Enabled = false;

                radioDeudaAgregar.Checked = false;
                RadioDeudaRestar.Checked = false;
            }
 

        }
       
        public void Refrescar() {
          
            radioDeudaAgregar.Enabled = false;
            checkHalf.Enabled = false;
            RadioDeudaRestar.Enabled = false;
            Full2.Enabled = true;
            Guardar.Enabled = false;
            radioDeudaAgregar.Checked = false;
            RadioDeudaRestar.Checked = false;
            CheckAmbos.Checked = false;
            checkAnto.Checked = false;
            checkNacho.Checked = false;
            checkHalf.Checked = true;
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
            }
            else {
                checkHalf.Checked = true;
            }
        }

        private void checkHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHalf.Checked)
            {
                Full2.Checked = false;
            }
            else
            {
                Full2.Checked = true;
            }
        }

        private void MontoNacho2_TextChanged(object sender, EventArgs e)
        {
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
                    var2 = Convert.ToInt32(MontoGastado.Text);
                    MontoAnto2.Text = Convert.ToString(var2 - var1);
                }
                else
                {

                    var1 = Convert.ToInt32(MontoNacho2.Text);
                    if (MontoGastado.Text == "")
                    {
                        MontoGastado.Text = "0";
                    }
                    var2 = Convert.ToInt32(MontoGastado.Text);
                    MontoAnto2.Text = Convert.ToString(var2 - var1);

                }


            }
        }

        private void MontoAnto2_TextChanged(object sender, EventArgs e)
        {
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
                MontoNacho2.Text = "";
                MontoAnto2.Text = "";

            if (MontoGastado.Text == "0")
            {

                MontoGastado.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = true;
        }

        private void RadioDeudaRestar_CheckedChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = true;
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

    }


}
