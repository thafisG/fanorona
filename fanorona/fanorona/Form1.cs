using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanorona
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        public bool turno = true;

        PictureBox botaoEmSi;

        private void TableEntrada_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Pecas_mouseDown(object sender, MouseEventArgs e)
        {
            PictureBox peca = (PictureBox)sender;
          



            if(turno == true)
            {
                if(peca.Tag.ToString() == "policia")
                {
                    peca.DoDragDrop(peca, DragDropEffects.Copy);
                }
                else { }
            }
            else
            {
                if (peca.Tag.ToString() == "cangaco")
                {
                    peca.DoDragDrop(peca, DragDropEffects.Copy);
                }
                else { }
            }
        }

        private void TableEntrada_DragDrop(object sender, DragEventArgs e)
        {

            PictureBox botao = (PictureBox)e.Data.GetData(typeof(PictureBox));
            e.Effect = DragDropEffects.Copy;
            Point loc = tableEntrada.PointToClient(new Point(e.X, e.Y));

            //determina a localização da célula

            int ColumnIndex = -1;
            int RowIndex = -1;
            int x = 0;
            int y = 0;

            while (ColumnIndex <= tableEntrada.ColumnCount)
            {
                if (loc.X < x)
                {
                    break;
                }

                ColumnIndex++;
                x += tableEntrada.GetColumnWidths()[ColumnIndex];
            }

            while (RowIndex <= tableEntrada.RowCount)
            {

                if (loc.Y < y)
                {
                    break;
                }

                RowIndex++;
                y += tableEntrada.GetRowHeights()[RowIndex];
            }

            TableLayoutPanelCellPosition posicao = tableEntrada.GetPositionFromControl(botao);

            PictureBox existeBotao = tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex) as PictureBox;
            botaoEmSi = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex);
            PictureBox pecaMovida = (PictureBox)tableEntrada.GetControlFromPosition(posicao.Column, posicao.Row);

            if(botaoEmSi.Image != null)
            {
                MessageBox.Show("Já existe uma peça nessa posição");
                    

            }
            else
            {
                if (turno == true)
                {

                    botaoEmSi.Image = Properties.Resources.chapeu_poliça_peça;
                    pecaMovida.Image = null;
                    botaoEmSi.Tag = "policia";
                    pecaMovida.Tag = "";

                }
                else
                {
                    botaoEmSi.Image = Properties.Resources.chapeu_canganço_peça;
                    pecaMovida.Image = null;
                    botaoEmSi.Tag = "cangaco";
                    pecaMovida.Tag = "";
                }
            }
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(turno == true)
            {
                turno = false;
            }
            else
            {
                turno = true;
            }
        }
    }
}
