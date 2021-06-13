using System;
using BDproj;
using BDproj.Clases;
using Gtk;
using MySql.Data.MySqlClient;

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
        //Utiliza
        TablaUtil.AppendColumn(Columnaid_ingred);
        TablaUtil.AppendColumn(ColumnaCantidad);
        CellRendererText utilNameCell = new CellRendererText();
        Columnaid_ingred.PackStart(utilNameCell, true);
        Columnaid_ingred.AddAttribute(utilNameCell, "text", 1);
        ColumnaCantidad.PackStart(utilNameCell, true);
        ColumnaCantidad.AddAttribute(utilNameCell, "text", 2); 
        //Utiliza
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
        //Categoria
        CellRendererText CategoriaNameCell = new CellRendererText();
        Columnaid_plato1.PackStart(CategoriaNameCell, true);
        Columnaid_plato1.AddAttribute(CategoriaNameCell, "text", 1);
        ColumnaDescri.PackStart(CategoriaNameCell, true);
        ColumnaDescri.AddAttribute(CategoriaNameCell, "text", 2);
        Columnaid_encarg.PackStart(CategoriaNameCell, true);
        Columnaid_encarg.AddAttribute(CategoriaNameCell, "text", 3);
        //Categoria
        //Encargado
        CellRendererText EncargadoNameCell = new CellRendererText();
        Columnaid_encarg1.PackStart(EncargadoNameCell, true);
        Columnaid_encarg1.AddAttribute(EncargadoNameCell, "text", 0);
        TreeViewColumn ColumnaNombre = new TreeViewColumn
        {
            Title = "Nombre",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaEnc.AppendColumn(ColumnaNombre);
        ColumnaNombre.PackStart(EncargadoNameCell, true);
        ColumnaNombre.AddAttribute(EncargadoNameCell, "text", 1);
        TreeViewColumn ColumnaApellido = new TreeViewColumn //forma base
        {
            Title = "Apellido",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaEnc.AppendColumn(ColumnaApellido);//forma base 
        ColumnaApellido.PackStart(EncargadoNameCell, true);
        ColumnaApellido.AddAttribute(EncargadoNameCell, "text", 2);
        //Plato
        CellRendererText PlatoNameCell = new CellRendererText();

        TreeViewColumn Columnaid_plato2 = new TreeViewColumn
        {
            Title = "id plato",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlato.AppendColumn(Columnaid_plato2);
        Columnaid_plato2.PackStart(PlatoNameCell, true);
        Columnaid_plato2.AddAttribute(PlatoNameCell, "text", 0); 
        TreeViewColumn ColumnaPrecio = new TreeViewColumn
        {
            Title = "Precio",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        }; 
        TablaPlato.AppendColumn(ColumnaPrecio);
        ColumnaPrecio.PackStart(PlatoNameCell, true);
        ColumnaPrecio.AddAttribute(PlatoNameCell, "text", 1);
        //ingrediente
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
        CellRendererText IngredNameCell = new CellRendererText();
        TablaIng.AppendColumn(Columnaid_ing);
        TablaIng.AppendColumn(ColumnaIng);
        TablaIng.AppendColumn(ColumnaAlmacen);
        TablaIng.AppendColumn(ColumnaUnid);
        Columnaid_ing.PackStart(IngredNameCell, true);
        Columnaid_ing.AddAttribute(IngredNameCell, "text", 0);
        ColumnaIng.PackStart(IngredNameCell, true);
        ColumnaIng.AddAttribute(IngredNameCell, "text", 1);
        ColumnaAlmacen.PackStart(IngredNameCell, true);
        ColumnaAlmacen.AddAttribute(IngredNameCell, "text", 2);
        ColumnaUnid.PackStart(IngredNameCell, true);
        ColumnaUnid.AddAttribute(IngredNameCell, "text", 3);
        //Platillo
        CellRendererText PlatilloNameCell = new CellRendererText();
        TreeViewColumn Columnaid_Platillo = new TreeViewColumn
        {
            Title = "id Platillo",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlatillo.AppendColumn(Columnaid_Platillo);
        Columnaid_Platillo.PackStart(PlatilloNameCell, true);
        Columnaid_Platillo.AddAttribute(PlatilloNameCell, "text", 0);
        TreeViewColumn Columnaid_plato3= new TreeViewColumn
        {
            Title = "id Plato",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlatillo.AppendColumn(Columnaid_plato3);
        Columnaid_plato3.PackStart(PlatilloNameCell, true);
        Columnaid_plato3.AddAttribute(PlatilloNameCell, "text", 1);
        TreeViewColumn ColumnaDescripcion = new TreeViewColumn
        {
            Title = "Descripcion",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlatillo.AppendColumn(ColumnaDescripcion);
        ColumnaDescripcion.PackStart(PlatilloNameCell, true);
        ColumnaDescripcion.AddAttribute(PlatilloNameCell, "text", 2);
        TreeViewColumn Columnanivel = new TreeViewColumn
        {
            Title = "Nivel",
            Expand = true,
            Sizing = TreeViewColumnSizing.Fixed
        };
        TablaPlatillo.AppendColumn(Columnanivel);
        Columnanivel.PackStart(PlatilloNameCell, true);
        Columnanivel.AddAttribute(PlatilloNameCell, "text", 3);

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
        //Categoria, plato, ingrediente, platillo, encargado y utiliza
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
            //No imprime nada?
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
        MessageDialog mensaje = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Error: "+x);
        mensaje.Run();
        mensaje.Destroy();
    }
    void Mensaje(string x)
    {
        MessageDialog mensaje = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, ""+ x);
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
        //MensajeError("" +notebook3.Page);
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
            bd.Conectar();
            string sql;
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
                    sql = "INSERT INTO `categoria` (`id_categoria`, `id_plato`, `descripcion`, `id_encargado`) " +
                    	$"VALUES ('{categ.id_categoria}', '{categ.id_plato}', '{categ.Descripcion}', '{categ.id_encargado}');";
                    //$"VALUES ('CAT-0088', 'PLAT40', 'Plato de prueba', 'ENC12');";
                    bd.Insertar(sql);
                    Mensaje("Se a insertado el registro");
                    break;
                case 1:
                    enc = new Encargado
                    {
                        id_encargado = cmbeEncid.Entry.Text,
                        Nombre = entNombre.Text,
                        Apellido = entApellido.Text
                    };
                    sql = "INSERT INTO `encargado` (`id_encargado`, `nombre`, `apellido`) " +
                        $"VALUES ('{enc.id_encargado}', '{enc.Nombre}', '{enc.Apellido}');";
                    bd.Insertar(sql);
                    Mensaje("Se a insertado el registro");
                    break;
                case 2:
                    ingred = new Ingred
                    {
                        id_ingrediente = cmbeIngid.Entry.Text,
                        Ingrediente = entingrediente.Text,
                        Almacen = entalmacen.Text,
                        Unidad = entunidad.Text
                    };
                    sql = "INSERT INTO `ingred` (`id_ingrediente`, `ingrediente`, `almacen`, `unidades`) " +
                        $"VALUES ('{ingred.id_ingrediente}', '{ingred.Ingrediente}', '{ingred.Almacen}', '{ingred.Unidad}');";
                    bd.Insertar(sql);
                    Mensaje("Se a insertado el registro");
                    break;
                case 3:
                    platillo = new Platillo
                    {
                        id_platillo = cmbePlatilloId.Entry.Text,
                        id_plato = cmbePlatilloidplato .Entry.Text,
                        Descripcion = entDescripcion.Text,
                        Nivel = entnivel.Text
                    };
                    sql = "INSERT INTO `platillo` (`id_platillo`, `id_plato`, `descripcion`, `nivel`) " +
                        $"VALUES ('{platillo.id_platillo}', '{platillo.id_plato}', '{platillo.Descripcion}', '{platillo.Nivel}');";
                    bd.Insertar(sql);
                    Mensaje("Se a insertado el registro");
                    break;
                case 4:
                    plato = new Plato
                    {
                        id_plato = cmbePlatId.Entry.Text,
                        Precio  = entprecio.Text
                    };
                    sql = "INSERT INTO `plato` (`id_plato`, `foto`, `precio`) " +
                       $"VALUES ('{plato.id_plato}', '{null}', '{plato.Precio}');";
                    bd.Insertar(sql);
                    Mensaje("Se a insertado el registro");
                    break;
                case 5:
                    util = new Utiliza
                    {
                        id_plato = cmbeUtilidPlat.Entry.Text,
                        id_ingrediente = cmbeUtilidIngred.Entry.Text,
                        Cantidad = entcant.Text
                    };
                    sql = "INSERT INTO `utiliza` (`id_plato`, `id_ingrediente`, `cantidad`) " +
                       $"VALUES ('{util.id_plato}', '{util.id_ingrediente}', '{util.Cantidad}');";
                    bd.Insertar(sql);
                    Mensaje("Se a insertado el registro");
                    break;
                default:
                    MensajeError("Ocurrio un error inesperado");
                    break;
            }
            MostrarTabla();
        }
        catch(Exception ex)
        {
            MensajeError("" + ex);
        }
        bd.Desconectar();
    }

    protected void btnDesco_desconectar(object sender, EventArgs e)
    {
        bd.Desconectar();
    }

    protected void btnMostrar_Clicked(object sender, EventArgs e)
    {
        MostrarTabla();
    }

    private void MostrarTabla()
    {
        string query;
        MySqlCommand valor;
        MySqlDataReader reader;
        try
        {
            switch (notebook1.Page)
            {
                case 0:
                    Lcategoria.Clear();
                    query = "SELECT * FROM `categoria`";
                    bd.Conectar();
                    valor = bd.ConsultarComando(query,"");
                    reader = valor.ExecuteReader();

                    while(reader.Read())
                    {
                        Lcategoria.AppendValues($"{reader["id_categoria"].ToString()}", $"{reader["id_plato"].ToString()}", $"{reader["descripcion"].ToString()}", $"{reader["id_encargado"].ToString()}");
                    }
                    reader.Close();
                    bd.Desconectar();
                    break;
                case 1:
                    Lencargado.Clear();
                    query = "SELECT * FROM `encargado`";
                    bd.Conectar();
                    valor = bd.ConsultarComando(query, "");
                    reader = valor.ExecuteReader();

                    while (reader.Read())
                    {
                        Lencargado.AppendValues($"{reader["id_encargado"].ToString()}", $"{reader["nombre"].ToString()}", $"{reader["apellido"].ToString()}");
                    }
                    reader.Close();
                    bd.Desconectar();
                    break;
                case 2:
                    LIngred.Clear();
                    query = "SELECT * FROM `ingred`";
                    bd.Conectar();
                    valor = bd.ConsultarComando(query, "");
                    reader = valor.ExecuteReader();

                    while (reader.Read())
                    {
                        LIngred.AppendValues($"{reader["id_ingrediente"].ToString()}", $"{reader["ingrediente"].ToString()}", $"{reader["almacen"].ToString()}", $"{ reader["unidades"].ToString()}");
                    }
                    reader.Close();
                    bd.Desconectar();
                    break;
                case 3:
                    LPlatillo.Clear();
                    query = "SELECT * FROM `platillo`";
                    bd.Conectar();
                    valor = bd.ConsultarComando(query, "");
                    reader = valor.ExecuteReader();

                    while (reader.Read())
                    {
                        LPlatillo.AppendValues($"{reader["id_platillo"].ToString()}", $"{reader["id_plato"].ToString()}", $"{reader["descripcion"].ToString()}", $"{reader["nivel"].ToString()}");
                    }
                    reader.Close();
                    bd.Desconectar();
                    break;
                case 4:
                    LPlato.Clear();
                    query = "SELECT * FROM `plato`";
                    bd.Conectar();
                    valor = bd.ConsultarComando(query, "");
                    reader = valor.ExecuteReader();

                    while (reader.Read())
                    {//Falta datos
                        LPlato.AppendValues($"{reader["id_plato"].ToString()}", $"{reader["precio"].ToString()}");
                    }
                    reader.Close();
                    bd.Desconectar();
                    break;
                case 5:
                    Lutiliza.Clear();
                    query = "SELECT * FROM `utiliza`";
                    bd.Conectar();
                    valor = bd.ConsultarComando(query, "");
                    reader = valor.ExecuteReader();

                    while (reader.Read())
                    {//Falta datos
                        Lutiliza.AppendValues($"{reader["id_plato"].ToString()}", $"{reader["id_ingrediente"].ToString()}", $"{reader["cantidad"].ToString()}");
                    }
                    reader.Close();
                    bd.Desconectar();
                    break;
                default:
                    MensajeError("Ocurrio un error inesperado");
                    break;
            }
        }catch(MySqlException exx)
        {
            MensajeError("Error: " + exx);
        }
        catch (Exception ex)
        {
            MensajeError("" + ex);
        }

    }

    protected void btnInfo_click(object sender, EventArgs e)
    {
        Window1 window = new Window1(ref bd);
        window.Show();
    }

    protected void btnUpdate_clieck(object sender, EventArgs e)
    {
        try
        {
            string update = "UPDATE `categoria` " +
                $"SET `id_categoria`='CATNUEVA',`id_plato`='PLAT37',`descripcion`='NUEVA',`id_encargado`='ENC16' WHERE id_categoria = 'CATUPDATE'";
            //string sql;
            MySqlCommand cmb;
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
                    update = "UPDATE `categoria` " +
                    $"SET `id_categoria`='{categ.id_categoria}',`id_plato`='{categ.id_plato}',`descripcion`='{categ.Descripcion}',`id_encargado`='{categ.id_encargado}' " +
                    	$"WHERE id_categoria = '{categ.id_categoria}'";
                    bd.Conectar();
                    cmb = bd.ConsultarComando(update, "");
                    cmb.ExecuteNonQuery();
                    Mensaje("Se a actualizado el registro");
                    bd.Desconectar();
                    break;
                case 1:
                    enc = new Encargado
                    {
                        id_encargado = cmbeEncid.Entry.Text,
                        Nombre = entNombre.Text,
                        Apellido = entApellido.Text
                    };
                    update = "UPDATE `encargado` " +
                    $"SET `id_encargado`='{enc.id_encargado}',`nombre`='{enc.Nombre}',`apellido`='{enc.Apellido}'" +
                        $"WHERE id_encargado = '{enc.id_encargado}'";
                    bd.Conectar();
                    cmb = bd.ConsultarComando(update, "");
                    cmb.ExecuteNonQuery();
                    Mensaje("Se a actualizado el registro");
                    bd.Desconectar();
                    break;
                case 2:
                    ingred = new Ingred
                    {
                        id_ingrediente = cmbeIngid.Entry.Text,
                        Ingrediente = entingrediente.Text,
                        Almacen = entalmacen.Text,
                        Unidad = entunidad.Text
                    };
                    update = "UPDATE `ingred` " +
                    $"SET `id_ingrediente`='{ingred.id_ingrediente}',`ingrediente`='{ingred.Ingrediente}',`almacen`='{ingred.Almacen}',`unidades`='{ingred.Unidad}' " +
                        $"WHERE id_ingrediente = '{ingred.Unidad}'";
                    bd.Conectar();
                    cmb = bd.ConsultarComando(update, "");
                    cmb.ExecuteNonQuery();
                    Mensaje("Se a actualizado el registro");
                    bd.Desconectar();
                    break;
                case 3:
                    platillo = new Platillo
                    {
                        id_platillo = cmbePlatilloId.Entry.Text,
                        id_plato = cmbePlatilloidplato.Entry.Text,
                        Descripcion = entDescripcion.Text,
                        Nivel = entnivel.Text
                    };
                    update = "UPDATE `categoria` " +
                    $"SET `id_platillo`='{platillo.id_platillo}',`id_plato`='{platillo.id_plato}',`descripcion`='{platillo.Descripcion}',`nivel`='{platillo.Nivel}' " +
                        $"WHERE id_categoria = '{platillo.id_platillo}'";
                    bd.Conectar();
                    cmb = bd.ConsultarComando(update, "");
                    cmb.ExecuteNonQuery();
                    Mensaje("Se a actualizado el registro");
                    bd.Desconectar();
                    break;
                case 4:
                    plato = new Plato
                    {
                        id_plato = cmbePlatId.Entry.Text,
                        Precio = entprecio.Text
                    };
                    update = "UPDATE `plato` " +
                    $"SET `id_plato`='{plato.id_plato}',`precio`='{plato.Precio}'" +
                        $"WHERE id_categoria = '{categ.id_categoria}'";
                    bd.Conectar();
                    cmb = bd.ConsultarComando(update, "");
                    cmb.ExecuteNonQuery();
                    Mensaje("Se a actualizado el registro");
                    bd.Desconectar();
                    break;
                case 5:
                    util = new Utiliza
                    {
                        id_plato = cmbeUtilidPlat.Entry.Text,
                        id_ingrediente = cmbeUtilidIngred.Entry.Text,
                        Cantidad = entcant.Text
                    };
                    update = "UPDATE `utiliza` " +
                    $"SET `id_plato`='{util.id_plato}',`id_ingrediente`='{util.id_ingrediente}',`descripcion`='{util.Cantidad}'" +
                        $"WHERE id_categoria = '{categ.id_categoria}'";
                    bd.Conectar();
                    cmb = bd.ConsultarComando(update, "");
                    cmb.ExecuteNonQuery();
                    Mensaje("Se a actualizado el registro");
                    bd.Desconectar();
                    break;
                default:
                    MensajeError("Ocurrio un error inesperado");
                    break;
            }
            MostrarTabla();
        }
        catch (Exception ex)
        {
            MensajeError(""+ex);
        }
    }

    protected void btnBorrar_cleck(object sender, EventArgs e)
    {
 
    }

    protected void OnTablaEncSelectCursorRow(object o, SelectCursorRowArgs args)
    {

    }

    protected void btnBorrar_clicked(object sender, EventArgs e)
    {
        string delete;
        MySqlCommand cmd;
        try
        {
            switch (notebook3.Page)
            {
                case 0:
                    categ = new Categoria
                    {
                        id_categoria = cmbeCatIdcateg.Entry.Text
                    };
                    delete = "DELETE FROM `categoria` " +
                        $"WHERE categoria.id_categoria = '{categ.id_categoria}'";

                    bd.Conectar();
                    cmd = bd.ConsultarComando(delete, "");
                    cmd.ExecuteNonQuery();
                    Mensaje("Se a eliminado correctamente");
                    bd.Desconectar();
                    break;
                case 1:
                    enc = new Encargado
                    {
                        id_encargado = cmbeEncid.Entry.Text
                    };
                    delete = "DELETE FROM `encargado` " +
                        $"WHERE encargado.id_encargado = '{enc.id_encargado}'";
                    bd.Conectar();
                    cmd = bd.ConsultarComando(delete, "");
                    cmd.ExecuteNonQuery();
                    Mensaje("Se a eliminado correctamente");
                    bd.Desconectar();
                    break;
                case 2:
                    ingred = new Ingred
                    {
                        id_ingrediente = cmbeIngid.Entry.Text
                    };
                    delete = "DELETE FROM `ingred` " +
                        $"WHERE ingred.id_ingrediente = '{ingred.id_ingrediente}'";
                    bd.Conectar();
                    cmd = bd.ConsultarComando(delete, "");
                    cmd.ExecuteNonQuery();
                    Mensaje("Se a eliminado correctamente");
                    bd.Desconectar();
                    break;
                case 3:
                    platillo = new Platillo
                    {
                        id_platillo = cmbePlatilloId.Entry.Text
                    };
                    delete = "DELETE FROM `platillo` " +
                        $"WHERE platillo.id_platillo = '{platillo.id_platillo}'";
                    bd.Conectar();
                    cmd = bd.ConsultarComando(delete, "");
                    cmd.ExecuteNonQuery();
                    Mensaje("Se a eliminado correctamente");
                    bd.Desconectar();
                    break;
                case 4:
                    plato = new Plato
                    {
                        id_plato = cmbePlatId.Entry.Text
                    };
                    delete = "DELETE FROM `plato` " +
                        $"WHERE plato.id_plato = '{plato.id_plato}'";
                    bd.Conectar();
                    cmd = bd.ConsultarComando(delete, "");
                    cmd.ExecuteNonQuery();
                    Mensaje("Se a eliminado correctamente");
                    bd.Desconectar();
                    break;
                case 5:
                    util = new Utiliza
                    {
                        id_plato = cmbeUtilidPlat.Entry.Text,
                        id_ingrediente = cmbeUtilidIngred.Entry.Text
                    };
                    delete = "DELETE FROM `utiliza` " +
                        $"WHERE id_plato = '{util.id_plato}' AND " +
                        	$"id_ingrediente = '{util.id_ingrediente}'";
                    bd.Conectar();
                    cmd = bd.ConsultarComando(delete, "");
                    cmd.ExecuteNonQuery();
                    Mensaje("Se a eliminado correctamente");
                    bd.Desconectar();
                    break;
                default:
                    MensajeError("Ocurrio un error inesperado");
                    break;
            }
            MostrarTabla();
        }
        catch (Exception ex)
        {
            MensajeError("" + ex);
        }
    }

    protected void BtnMostrar_clicker(object sender, EventArgs e)
    {
        MostrarTabla();
    }

    protected void BtnInsertar_Clicked(object sender, EventArgs e)
    {
        btnInsertar_insertar(sender, e);
    }

    protected void Especial(object sender, EventArgs e)
    {
        LPlato.Clear();
        string query = "SELECT * FROM `plato` WHERE plato.precio >'50000'";
        bd.Conectar();
        var valor = bd.ConsultarComando(query, "");
        var reader = valor.ExecuteReader();

        while (reader.Read())
        {//Falta datos
            LPlato.AppendValues($"{reader["id_plato"].ToString()}", $"{reader["precio"].ToString()}");
        }
        reader.Close();
        bd.Desconectar();
    }
}
