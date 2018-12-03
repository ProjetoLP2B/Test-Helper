using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Log;

namespace WindowsFormsApp1
{
    public partial class InserirIndicador : Form
    {
        Usuario user = null;
        bool altera = false,exibir = false;
        public InserirIndicador(Usuario user)
        {
            this.user = user;
            InitializeComponent();
            altera = false;
            exibir = false;
        }
        public InserirIndicador(Indicador indicador, Usuario user)
        {
            this.user = user;
            InitializeComponent();
            altera = true;
            exibir = false;
            label1.Text = "Alterar Indicador";
            this.Text = "Alterar Indicador";
            try
            {
                txtIdIndicador.Text = Convert.ToString(indicador.id);
                txtNomeIndicador.Text = Convert.ToString(indicador.nome);
                txtObservacaoIndicador.Text = Convert.ToString(indicador.observacao);
                txtDescricaoIndicador.Text = Convert.ToString(indicador.descricao);
            }
            catch { }
        }

        public InserirIndicador(Indicador indicador)
        {
            InitializeComponent();
            altera = false;
            exibir = true;
            label1.Text = "Exibir Indicador";
            this.Text = "Exibir Indicador";
            try
            {
                txtIdIndicador.Text = Convert.ToString(indicador.id);
                txtNomeIndicador.Text = Convert.ToString(indicador.nome);
                txtObservacaoIndicador.Text = Convert.ToString(indicador.observacao);
                txtDescricaoIndicador.Text = Convert.ToString(indicador.descricao);
            }
            catch { }
        }

        private void btnCancelarIndicador_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InserirIndicador_Load(object sender, EventArgs e)
        {
            if (exibir)
            {
                btnConfirmarIndicador.Visible = false;
                txtDescricaoIndicador.ReadOnly = true;
                txtObservacaoIndicador.ReadOnly = true;
                txtNomeIndicador.ReadOnly = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmarIndicador_Click(object sender, EventArgs e)
        {
            if (!exibir)
            {
                Indicador indicador = new Indicador();
                indicador.nome = txtNomeIndicador.Text;
                indicador.observacao = txtObservacaoIndicador.Text;
                indicador.descricao = txtDescricaoIndicador.Text;
                IndicadorDao indicadordao = new IndicadorDao();
                LogDAO logdao = new LogDAO();

                if (altera)
                {
                    indicador.id = Convert.ToInt32(txtIdIndicador.Text);
                    indicadordao.editar(indicador);
                    logdao.inserir(user, "Indicador Alterado id=" + indicador.id + " id user=" + user.id);
                }
                else
                {
                    indicadordao.inserir(indicador);
                    logdao.inserir(user, "Indicador Inserido, id user=" + user.id);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

    }
}

