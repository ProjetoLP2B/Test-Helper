using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InserirUsuario : Form
    {
        public InserirUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
          //  usuario.id = Convert.ToInt32(txtIdUsuario.Text);
            usuario.nome = txtNomeUsuario.Text;
            usuario.sobrenome = txtSobrenomeUsuario.Text;
            usuario.email = txtEmailUsuario.Text;
            usuario.senha = txtSenhaUsuario.Text;
            UsuarioDAO usuariodao = new UsuarioDAO();
            usuariodao.inserir(usuario);
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
