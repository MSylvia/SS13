// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_IcecreamVat : Obj_Machinery {

		public ByTable product_types = new ByTable();
		public double? dispense_flavour = 1;
		public string flavour_name = "vanilla";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.flags = 20480;
			this.reagents = new Reagents();
			this.icon = "icons/obj/kitchen.dmi";
			this.icon_state = "icecream_vat";
		}

		// Function from file: icecream_vat.dm
		public Obj_Machinery_IcecreamVat ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			while (this.product_types.len < 6) {
				this.product_types.Add( 5 );
			}
			this.reagents.my_atom = this;
			this.reagents.add_reagent( "milk", 5 );
			this.reagents.add_reagent( "flour", 5 );
			this.reagents.add_reagent( "sugar", 5 );
			this.reagents.add_reagent( "ice", 5 );
			this.reagents.add_reagent( "cocoa", 5 );
			this.reagents.add_reagent( "berryjuice", 5 );
			this.reagents.add_reagent( "singulo", 5 );
			return;
		}

		// Function from file: icecream_vat.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			double? dispense_cone = null;
			string cone_name = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream I = null;
			double? amount = null;
			double? C = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["select"] ) ) {
				this.dispense_flavour = String13.ParseNumber( href_list["select"] );
				this.flavour_name = this.get_flavour_name( this.dispense_flavour );
				this.visible_message( "<span class='notice'>" + Task13.User + " sets " + this + " to dispense " + this.flavour_name + " flavoured ice cream.</span>" );
			}

			if ( Lang13.Bool( href_list["cone"] ) ) {
				dispense_cone = String13.ParseNumber( href_list["cone"] );
				cone_name = this.get_flavour_name( dispense_cone );

				if ( Convert.ToDouble( this.product_types[dispense_cone] ) >= 1 ) {
					this.product_types[dispense_cone] -= 1;
					I = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream( this.loc );
					I.cone_type = cone_name;
					I.icon_state = "icecream_cone_" + cone_name;

					switch ((string)( I.cone_type )) {
						case "waffle":
							I.reagents.add_reagent( "nutriment", 1 );
							break;
						case "chocolate":
							I.reagents.add_reagent( "cocoa", 1 );
							break;
					}
					I.desc = "Delicious " + cone_name + " cone, but no ice cream.";
					this.visible_message( "<span class='info'>" + Task13.User + " dispenses a crunchy " + cone_name + " cone from " + this + ".</span>" );
				} else {
					Task13.User.WriteMsg( "<span class='warning'>There are no " + cone_name + " cones left!</span>" );
				}
			}

			if ( Lang13.Bool( href_list["make"] ) ) {
				amount = String13.ParseNumber( href_list["amount"] );
				C = String13.ParseNumber( href_list["make"] );
				this.make( Task13.User, C, amount );
			}

			if ( Lang13.Bool( href_list["disposeI"] ) ) {
				this.reagents.del_reagent( href_list["disposeI"] );
			}
			this.updateDialog();

			if ( Lang13.Bool( href_list["refresh"] ) ) {
				this.updateDialog();
			}

			if ( Lang13.Bool( href_list["close"] ) ) {
				Task13.User.unset_machine();
				Interface13.Browse( Task13.User, null, "window=icecreamvat" );
			}
			return null;
		}

		// Function from file: icecream_vat.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic I = null;

			
			if ( A is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream ) {
				I = A;

				if ( !I.ice_creamed ) {
					
					if ( Convert.ToDouble( this.product_types[this.dispense_flavour] ) > 0 ) {
						this.visible_message( new Txt().icon( this ).str( " <span class='info'>" ).item( user ).str( " scoops delicious " ).item( this.flavour_name ).str( " ice cream into " ).item( I ).str( ".</span>" ).ToString() );
						this.product_types[this.dispense_flavour] -= 1;
						((Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream)I).add_ice_cream( this.flavour_name );

						if ( ( I.reagents.total_volume ??0) < 10 ) {
							I.reagents.add_reagent( "sugar", 10 - ( I.reagents.total_volume ??0) );
						}
					} else {
						user.WriteMsg( "<span class='warning'>There is not enough ice cream left!</span>" );
					}
				} else {
					user.WriteMsg( "<span class='notice'>" + A + " already has ice cream in it.</span>" );
				}
				return 1;
			} else if ( Lang13.Bool( ((Ent_Static)A).is_open_container() ) ) {
				return null;
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: icecream_vat.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			dynamic dat = null;
			Reagent R = null;
			Browser popup = null;

			dat += "<b>ICE CREAM</b><br><div class='statusDisplay'>";
			dat += "<b>Dispensing: " + this.flavour_name + " icecream </b> <br><br>";
			dat += new Txt( "<b>Vanilla ice cream:</b> <a href='?src=" ).Ref( this ).str( ";select=" ).item( 1 ).str( "'><b>Select</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 1 ).str( ";amount=1'><b>Make</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 1 ).str( ";amount=5'><b>x5</b></a> " ).item( this.product_types[1] ).str( " scoops left. (Ingredients: milk, ice)<br>" ).ToString();
			dat += new Txt( "<b>Strawberry ice cream:</b> <a href='?src=" ).Ref( this ).str( ";select=" ).item( 3 ).str( "'><b>Select</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 3 ).str( ";amount=1'><b>Make</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 3 ).str( ";amount=5'><b>x5</b></a> " ).item( this.product_types[3] ).str( " dollops left. (Ingredients: milk, ice, berry juice)<br>" ).ToString();
			dat += new Txt( "<b>Chocolate ice cream:</b> <a href='?src=" ).Ref( this ).str( ";select=" ).item( 2 ).str( "'><b>Select</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 2 ).str( ";amount=1'><b>Make</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 2 ).str( ";amount=5'><b>x5</b></a> " ).item( this.product_types[2] ).str( " dollops left. (Ingredients: milk, ice, coco powder)<br>" ).ToString();
			dat += new Txt( "<b>Blue ice cream:</b> <a href='?src=" ).Ref( this ).str( ";select=" ).item( 4 ).str( "'><b>Select</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 4 ).str( ";amount=1'><b>Make</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 4 ).str( ";amount=5'><b>x5</b></a> " ).item( this.product_types[4] ).str( " dollops left. (Ingredients: milk, ice, singulo)<br></div>" ).ToString();
			dat += "<br><b>CONES</b><br><div class='statusDisplay'>";
			dat += new Txt( "<b>Waffle cones:</b> <a href='?src=" ).Ref( this ).str( ";cone=" ).item( 5 ).str( "'><b>Dispense</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 5 ).str( ";amount=1'><b>Make</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 5 ).str( ";amount=5'><b>x5</b></a> " ).item( this.product_types[5] ).str( " cones left. (Ingredients: flour, sugar)<br>" ).ToString();
			dat += new Txt( "<b>Chocolate cones:</b> <a href='?src=" ).Ref( this ).str( ";cone=" ).item( 6 ).str( "'><b>Dispense</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 6 ).str( ";amount=1'><b>Make</b></a> <a href='?src=" ).Ref( this ).str( ";make=" ).item( 6 ).str( ";amount=5'><b>x5</b></a> " ).item( this.product_types[6] ).str( " cones left. (Ingredients: flour, sugar, coco powder)<br></div>" ).ToString();
			dat += "<br>";
			dat += "<b>VAT CONTENT</b><br>";

			foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
				R = _a;
				
				dat += "" + R.name + ": " + R.volume;
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";disposeI=" ).item( R.id ).str( "'>Purge</A><BR>" ).ToString();
			}
			dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";refresh=1'>Refresh</a> <a href='?src=" ).Ref( this ).str( ";close=1'>Close</a>" ).ToString();
			popup = new Browser( user, "icecreamvat", "Icecream Vat", 700, 500, this );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: icecream_vat.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			((Mob)a).set_machine( this );
			this.interact( a );
			return null;
		}

		// Function from file: icecream_vat.dm
		public void make( Mob user = null, double? make_type = null, double? amount = null ) {
			dynamic R = null;
			dynamic R2 = null;
			string flavour = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.get_ingredient_list( make_type ) )) {
				R = _a;
				

				if ( Lang13.Bool( this.reagents.has_reagent( R, amount ) ) ) {
					continue;
				}
				amount = 0;
				break;
			}

			if ( Lang13.Bool( amount ) ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.get_ingredient_list( make_type ) )) {
					R2 = _b;
					
					this.reagents.remove_reagent( R2, amount );
				}
				this.product_types[make_type] += amount;
				flavour = this.get_flavour_name( make_type );

				if ( ( make_type ??0) > 4 ) {
					this.visible_message( "<span class='info'>" + user + " cooks up some " + flavour + " cones.</span>" );
				} else {
					this.visible_message( "<span class='info'>" + user + " whips up some " + flavour + " icecream.</span>" );
				}
			} else {
				user.WriteMsg( "<span class='warning'>You don't have the ingredients to make this!</span>" );
			}
			return;
		}

		// Function from file: icecream_vat.dm
		public string get_flavour_name( double? flavour_type = null ) {
			
			switch ((int?)( flavour_type )) {
				case 2:
					return "chocolate";
					break;
				case 3:
					return "strawberry";
					break;
				case 4:
					return "blue";
					break;
				case 5:
					return "waffle";
					break;
				case 6:
					return "chocolate";
					break;
				default:
					return "vanilla";
					break;
			}
			return null;
		}

		// Function from file: icecream_vat.dm
		public ByTable get_ingredient_list( double? type = null ) {
			
			switch ((int?)( type )) {
				case 2:
					return new ByTable(new object [] { "milk", "ice", "cocoa" });
					break;
				case 3:
					return new ByTable(new object [] { "milk", "ice", "berryjuice" });
					break;
				case 4:
					return new ByTable(new object [] { "milk", "ice", "singulo" });
					break;
				case 5:
					return new ByTable(new object [] { "flour", "sugar" });
					break;
				case 6:
					return new ByTable(new object [] { "flour", "sugar", "cocoa" });
					break;
				default:
					return new ByTable(new object [] { "milk", "ice" });
					break;
			}
			return null;
		}

	}

}