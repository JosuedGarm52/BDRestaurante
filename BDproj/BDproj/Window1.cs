using System;
using Gtk;

namespace BDproj
{
    public partial class Window1 : Gtk.Window
    {
        public Window1(ref BaseDato dato) :base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            baseDato = dato;
        }
        BaseDato baseDato;
        protected void btnConectar_click(object sender, EventArgs e)
        {
            try
            {
                baseDato.CambiarDatabase(entServer.Text, entData.Text, entUser.Text, entPassword.Text);
                MessageDialog mensajex = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Datos introducidos");
                mensajex.Run();
                mensajex.Destroy();
            }
            catch (Exception ex)
            {
                MensajeError("" + ex);
            }
        }

        protected void btnComprobar_Click(object sender, EventArgs e)
        {
            try
            {
                baseDato.Conectar();
                MessageDialog mensajex = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "La base se conecta con exito");
                mensajex.Run();
                mensajex.Destroy();
                baseDato.Desconectar();
            }
            catch (Exception ex)
            {
                MensajeError("" + ex);
            }
        }
        void MensajeError(string x)
        {
            MessageDialog mensaje = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Error: " + x);
            mensaje.Run();
            mensaje.Destroy();
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
