using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastrodeContatos
{
    public partial class frmAgendaDeContatos : Form
    {

        SqlConnection con = new SqlConnection("Data Source=PC03LAB2929\\SENAI; Initial Catalog=CadastrodeContatos; User Id=sa; Password=senai.123");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;

        public frmAgendaDeContatos()
        {
            InitializeComponent();
            ExibirDados();
            LimparDados();
        }

        private void ExibirDados()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT * FROM Contato", con);
                adapt.Fill(dt);
                dgvCadastrodeContatos.DataSource = dt;
            }
            catch
            { 
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private void LimparDados()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            ID = 0;
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair da agenda?", "Agenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                txtNome.Focus();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (ID != 0) 
            {
                if (MessageBox.Show("Deseja realmente deletar este registro?", "Agenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                {
                    try
                    {
                        cmd = new SqlCommand("DELETE Contato WHERE id=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro deletado com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro:" + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                        ExibirDados();
                        LimparDados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione o registro que deseja deletar.");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" )
        }
    }
}


