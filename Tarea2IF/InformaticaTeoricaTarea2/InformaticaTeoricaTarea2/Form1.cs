using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformaticaTeoricaTarea2
{
    public partial class FNC : Form
    {
        //******************************
        // ATRIBUTOS
        //******************************

        private Grammar g;
        private Hashtable unitaries;

        public FNC()
        {
            InitializeComponent();
            unitaries = new Hashtable();
            txtNoAlcanzables.ReadOnly = true;
            txtNoTerminales.ReadOnly = true;
            txtUnitarias.ReadOnly = true;
            txtAnulables.ReadOnly = true;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FNC_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                if (txtGramatica.Text.Trim().Count() > 0)
                {

                    try
                    {

                       //Elimino variables no terminales.

                        g = new Grammar(txtGramatica.Text);

                        List<string> noTerminals = g.getNoTerminables();

                        string cadena = "";
                        if (noTerminals.Count() > 0)
                        {
                            cadena = "";
                            for (int i = 0; i < noTerminals.Count(); i++)
                            {
                                string noTerminable = noTerminals.ElementAt(i);

                                cadena = cadena + noTerminable + " ";
                            
                            }
                        }

                        
                        txtNoTerminales.Text = cadena;
                        g.removeNoTerminables();
            



                    //Ahora elimino no alcanzables

                    List<string> noAlcanzables = g.getNoAttainable();

                    string cadena2 = "";
                    if (noAlcanzables.Count() > 0)
                    {
                        cadena2 = "";
                        for (int i = 0; i < noAlcanzables.Count(); i++)
                        {
                            string noAlcanzable = noAlcanzables.ElementAt(i);

                            cadena2 = cadena2 + noAlcanzable + " ";
                        }
                    }

                    txtNoAlcanzables.Text = cadena2;
                    g.removeNoAttainable();
                    

                    //Ahora elimino las producciones lambda, excepto S : %


                    List<string> anulables = g.getVoidable();

                    string cadena3 = "";
                    if (anulables.Count() > 0)
                    {
                        cadena3 = "";
                        for (int i = 0; i < anulables.Count(); i++)
                        {
                            string anulable = anulables.ElementAt(i);

                            cadena3 = cadena3 + anulable + " ";
                        }
                    }

                    txtAnulables.Text = cadena3;
                    g.removeLambdaProductions();


                   

                    
                   




                    //Agregamos las unitarias de cada generador en la hashtable y al comboBox.

                    foreach (string variable in g.getGenerators())
                    {
                        cbUnitarias.Items.Add(variable);

                        string cadena4 = "";
                        List<string> conjunto = g.getUnitarySet(variable);

                        for (int i = 0; i < conjunto.Count(); i++)
                        {
                            cadena4 = cadena4 + conjunto.ElementAt(i) + " ";
                        }

                        unitaries.Add(variable, cadena4);

                    }


                    



                    //Ahora simulo las producciones unitarias

                    g.removeUnitariesProductions();
                    


                    //foreach (Production a in g.rules)
                    //{
                    //    Console.WriteLine(g.rules.Count());
                    //    Console.WriteLine(a.generator);
                    //    foreach (string b in a.productions)
                    //    {

                    //        Console.WriteLine(b);

                    //    }
                    //}



                    //Ahora generamos las variables por cada terminal.

                    try
                    {
                        
                        g.generateVariablesForEachTerminal();

                        //Console.WriteLine(g.ToString());
                     

                    }
                    catch (Exception ex)
                    {
                        //El unico error que se puede producir en esta fase, es que no hayan 
                        //suficientes variables para obtener producciones binarias
                        MessageBox.Show("No hay suficientes variables en el abecedario para generar " +
                            "producciones binarias con esta gramatica");
                        
                    }

                    //Ahora generamos la gramatica binaria.

                    try
                    {
                        
                        g.generateBinaryProductions();
                        txtResultado.Text = g.ToString();
                        

                        MessageBox.Show("La gramatica ha sido convertida a su Forma Normal de Chomsky" + Environment.NewLine +
                                        "¡Gracias por usar nuestro programa!");

                        
                    }
                    catch (Exception es)
                    {
                        //El unico error que se puede producir en esta fase, es que no hayan 
                        //suficientes variables para obtener producciones binarias
                        MessageBox.Show("No hay suficientes variables en el abecedario para generar " +
                            "producciones binarias con esta gramatica");
                        MessageBox.Show(es.Message);
                       
                    }



                }
                    catch (Exception ac)
                    {
                        MessageBox.Show(ac.Message);

                    }



                }
                else
                {
                    MessageBox.Show("Debe insertar una gramatica");
                }


            
            
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoAlcanzables_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoTerminales_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnulables_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbUnitarias_SelectedIndexChanged(object sender, EventArgs e)
        {

            string generador = (string)cbUnitarias.SelectedItem;

            string cadena = (string)unitaries[generador];
            
            txtUnitarias.Text = cadena;

        }

        private void txtUnitarias_TextChanged(object sender, EventArgs e)
        {

        }

        private void butLimpiar_Click(object sender, EventArgs e)
        {
            g = null;
            txtResultado.Clear();
            txtUnitarias.Clear();
            txtNoAlcanzables.Clear();
            txtNoTerminales.Clear();
            txtAnulables.Clear();
            cbUnitarias.Items.Clear();
            txtGramatica.Clear();
            unitaries.Clear();

            MessageBox.Show("Se ha borrado satisfactoriamente."+"\n"+"Ahora puedes ingresar otra GIC para convertirla en FNC");

        }

        private void txtGramatica_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
