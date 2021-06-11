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
    ListStore Lcategoria;
    ListStore Lutiliza;
    ListStore Lencargado;
    ListStore LPlato;
    ListStore LIngred;
    ListStore LPlatillo;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        //home/josue-user/Repos/ProyectoC/C#/BDProyecto/BDproj/BDproj/Recursos/RoboError.png
        //Configurar la columna
        TreeViewColumn Columnaid_plato = new TreeViewColumn
        {
            Title = "id plato",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn Columnaid_plato1 = new TreeViewColumn
        {
            Title = "id plato",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn Columnaid_ingred = new TreeViewColumn
        {
            Title = "id ingrediente",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn ColumnaCantidad = new TreeViewColumn
        {
            Title = "Cantidad",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn Columnaid_categ = new TreeViewColumn
        {
            Title = "id categoria",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn ColumnaDescri = new TreeViewColumn
        {
            Title = "Descripcion",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn Columnaid_encarg = new TreeViewColumn
        {
            Title = "id encargado",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn Columnaid_encarg1 = new TreeViewColumn
        {
            Title = "id encargado",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        //Crear el active cell
        CellRendererPixbuf activeCell = new Gtk.CellRendererPixbuf();
        //Añadirle a la columna creada el packstart
        Columnaid_plato.PackStart(activeCell, false);
        //Añadir a la columna creada el addAtribute
        Columnaid_plato.AddAttribute(activeCell, "pixbuf", 6);
        //Se añade a la tabla
        TablaUtil.AppendColumn(Columnaid_plato);
        //Comienza de nuevo
        Columnaid_ingred.PackStart(activeCell, false);
        Columnaid_ingred.AddAttribute(activeCell, "pixbuf", 6);
        ColumnaCantidad.PackStart(activeCell, false);
        ColumnaCantidad.AddAttribute(activeCell, "pixbuf", 6);
        Columnaid_categ.PackStart(activeCell, false);
        Columnaid_categ.AddAttribute(activeCell, "pixbuf", 6);
        Columnaid_encarg1.PackStart(activeCell, false);
        Columnaid_encarg1.AddAttribute(activeCell, "pixbuf", 6);
        TablaUtil.AppendColumn(Columnaid_ingred);
        TablaUtil.AppendColumn(ColumnaCantidad);
        TablaCat.AppendColumn(Columnaid_categ);
        //TreeViewColumn Columnaid_plato1 = Columnaid_plato;
        TablaCat.AppendColumn(Columnaid_plato1);
        TablaCat.AppendColumn(ColumnaDescri);
        TablaCat.AppendColumn(Columnaid_encarg);
        TablaEnc.AppendColumn(Columnaid_encarg1);
        CellRendererText id_platoNameCell = new CellRendererText();
        Columnaid_plato.PackStart(id_platoNameCell,true);
        Columnaid_plato.AddAttribute(id_platoNameCell, "text", 0);
        CellRendererText id_categoriaNameCell = new CellRendererText();
        Columnaid_categ.PackStart(id_categoriaNameCell, true);
        Columnaid_categ.AddAttribute(id_categoriaNameCell, "text", 0);
        CellRendererText id_plato1NameCell = new CellRendererText();
        Columnaid_plato1.PackStart(id_plato1NameCell, true);
        Columnaid_plato1.AddAttribute(id_plato1NameCell, "text", 1);
        CellRendererText id_EncargadoNameCell = new CellRendererText();
        Columnaid_encarg1.PackStart(id_EncargadoNameCell, true);
        Columnaid_encarg1.AddAttribute(id_EncargadoNameCell, "text", 0);
        TreeViewColumn ColumnaNombre = new TreeViewColumn
        {
            Title = "Nombre",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaEnc.AppendColumn(ColumnaNombre);
        TreeViewColumn ColumnaApellido = new TreeViewColumn //forma base
        {
            Title = "Apellido",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaEnc.AppendColumn(ColumnaApellido);//forma base 
        TreeViewColumn Columnaid_plato2 = new TreeViewColumn
        {
            Title = "id plato",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlato.AppendColumn(Columnaid_plato2);
        TreeViewColumn ColumnaPrecio = new TreeViewColumn
        {
            Title = "Precio",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        }; 
        TablaPlato.AppendColumn(ColumnaPrecio);
        TreeViewColumn Columnaid_ing = new TreeViewColumn
        {
            Title = "id ingrediente",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn ColumnaIng = new TreeViewColumn
        {
            Title = "Ingrediente",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn ColumnaAlmacen = new TreeViewColumn
        {
            Title = "Almacen",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TreeViewColumn ColumnaUnid = new TreeViewColumn
        {
            Title = "Unidad",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaIng.AppendColumn(Columnaid_ing);
        TablaIng.AppendColumn(ColumnaIng);
        TablaIng.AppendColumn(ColumnaAlmacen);
        TablaIng.AppendColumn(ColumnaUnid);
        TreeViewColumn Columnaid_Platillo = new TreeViewColumn
        {
            Title = "id Platillo",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlatillo.AppendColumn(Columnaid_Platillo);
        TreeViewColumn Columnaid_plato3= new TreeViewColumn
        {
            Title = "id Plato",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlatillo.AppendColumn(Columnaid_plato3);
        //El numero de typeifStrings depende a la cantidad de columnas
        Lutiliza = new Gtk.ListStore(typeof(string), typeof(string), typeof(string));
        Lcategoria = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
        Lencargado = new ListStore(typeof(string), typeof(string), typeof(string));
        LPlato = new ListStore(typeof(string), typeof(string));
        LIngred = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
        LPlatillo = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
        TablaUtil.Model = Lutiliza;
        TablaCat.Model = Lcategoria;
        TablaEnc.Model = Lencargado;
        TablaPlato.Model = LPlato;
        TablaIng.Model = LIngred;
        TablaPlatillo.Model = LPlatillo;
        this.ShowAll();
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

    protected void btnMostrar_Clicked(object sender, EventArgs e)
    {
    }
}
