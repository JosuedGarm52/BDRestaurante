using System;
using BDproj;
using BDproj.Clases;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    BaseDato bd = new BaseDato();
    Categoria categ;
    Encargado enc;
    Ingred ingred;
    Platillo platillo;
    Plato plato;
    Utiliza util;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }
    
    FileChooserButton fileChooserButton1 = new FileChooserButton(dialog);
    static Dialog dialog = new Dialog();
    string datoimagen;

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void comprobar_clicked(object sender, EventArgs e)
    {
        try
        {
            bd.Conectar();

            MessageDialog mensajex = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "La base se conecto con exito");
            mensajex.Run();
            mensajex.Destroy();
        }
        catch (Exception ex)
        {
            MessageDialog mensaje = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Error" + ex);
            mensaje.Run();
            mensaje.Destroy();
        }

    }

    protected void Salir(object sender, EventArgs e)
    {
        Application.Quit();
    }

    protected void Foto_clicked(object sender, EventArgs e)
    {
        try
        {
           string dato =(""+fileChooserButton1.Filename);
            datoimagen = dato;

        }catch(Exception ex)
        {
            MensajeError("Error"+ex);
        }
    }
    void MensajeError(string x)
    {
        MessageDialog mensaje = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, x);
        mensaje.Run();
        mensaje.Destroy();
    }
    void Mensaje(string x)
    {
        MessageDialog mensaje = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, x);
        mensaje.Run();
        mensaje.Destroy();
    }

    protected void note3_changecurrentpage(object o, ChangeCurrentPageArgs args)
    {
        MensajeError("Se cambio la pagina");
    }

    protected void note3_SwitchPage(object o, SwitchPageArgs args)
    {
        VaciarText1();
        MensajeError("" +notebook3.Page);
    }
    void VaciarText1()
    {
        cmbeEncid.Entry.Text = "";
        cmbeIngid.Entry.Text = "";
        cmbePlatId.Entry.Text = "";
        cmbeCatIdcateg.Entry.Text = "";
        cmbeCatIdEncar.Entry.Text = "";
        cmbeCatIdplato.Entry.Text = "";
        cmbePlatilloId.Entry.Text = "";
        cmbeUtilidPlat.Entry.Text = "";
        cmbeUtilidIngred.Entry.Text = "";
        cmbePlatilloidplato.Entry.Text = "";
        entcant.Text = "";
        entnivel.Text = "";
        entNombre.Text = "";
        entprecio.Text = "";
        entunidad.Text = "";
        entalmacen.Text = "";
        entCatDesc.Text = "";
        entApellido.Text = "";
        entDescripcion.Text = "";
        entingrediente.Text = "";
    }

    protected void btnInsertar_insertar(object sender, EventArgs e)
    {
        try
        {
            //if(notebook3.Page==0)
            switch (notebook3.Page)
            {
                case 0:
                    categ = new Categoria
                    {
                        id_categoria = cmbeCatIdcateg.Entry.Text,
                        id_plato = cmbeCatIdplato.Entry.Text,
                        Descripcion = entCatDesc.Text,
                        id_encargado = cmbeCatIdEncar.Entry.Text
                    };
                    string sql = "INSERT INTO `categoria` (`id_categoria`, `id_plato`, `descripcion`, `id_encargado`) " +
                    	$"VALUES ('{categ.id_categoria}', '{categ.id_plato}', '{categ.Descripcion}', '{categ.id_encargado}');";
                    //$"VALUES ('CAT-0088', 'PLAT40', 'Plato de prueba', 'ENC12');";
                    bd.Insertar(sql);
                    Mensaje("Se a insertado el registro");
                    break;
                case 1:
                    enc = new Encargado
                    {

                    };
                    break;
                case 2:
                    ingred = new Ingred
                    {
                       
                    };
                    break;
                case 3:
                    platillo = new Platillo
                    {

                    };
                    break;
                case 4:
                    plato = new Plato
                    {

                    };
                    break;
                case 5:
                    util = new Utiliza
                    {

                    };
                    break;
                default:
                    MensajeError("Ocurrio un error inesperado");
                    break;
            }
        }
        catch(Exception ex)
        {
            MensajeError("" + ex);
        }
    }

    protected void btnDesco_desconectar(object sender, EventArgs e)
    {
        bd.Desconectar();
    }
}
