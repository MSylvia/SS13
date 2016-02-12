// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SeedExtractor : Obj_Machinery {

		public ByTable piles = new ByTable();
		public double min_seeds = 1;
		public double max_seeds = 4;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.machine_flags = 30;
			this.icon = "icons/obj/hydroponics.dmi";
			this.icon_state = "sextractor";
		}

		// Function from file: seed_extractor.dm
		public Obj_Machinery_SeedExtractor ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_SeedExtractor(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MicroLaser(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_ConsoleScreen()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: seed_extractor.dm
		public bool hasSpaceCheck( dynamic user = null ) {
			
			if ( this.contents.len >= 999 ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( this ).item().str( " is full.</span>" ).ToString() );
				return false;
			} else {
				return true;
			}
		}

		// Function from file: seed_extractor.dm
		public void moveToStorage( dynamic O = null ) {
			Ent_Static S = null;
			SeedPile P = null;

			
			if ( O.loc is Obj_Item_Weapon_Storage ) {
				S = O.loc;
				((dynamic)S).remove_from_storage( O, this );
			}
			((Ent_Dynamic)O).forceMove( this );

			foreach (dynamic _a in Lang13.Enumerate( this.piles, typeof(SeedPile) )) {
				P = _a;
				

				if ( P.seed == O.seed ) {
					P.amount++;
					return;
				}
			}
			this.piles.Add( new SeedPile( O.seed ) );
			return;
		}

		// Function from file: seed_extractor.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? amt = null;
			Seed S = null;
			SeedPile P = null;
			Obj_Item_Seeds O = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			amt = String13.ParseNumber( href_list["amt"] );
			S = GlobalVars.plant_controller.seeds[href_list["seed"]];

			foreach (dynamic _a in Lang13.Enumerate( this.piles, typeof(SeedPile) )) {
				P = _a;
				

				if ( P.seed == S ) {
					
					if ( ( P.amount ??0) <= 0 ) {
						return null;
					}
					P.amount -= amt ??0;

					if ( ( P.amount ??0) <= 0 ) {
						this.piles.Remove( P );
						GlobalFuncs.qdel( P );
					}
					break;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Obj_Item_Seeds) )) {
				O = _b;
				

				if ( O.seed == S ) {
					O.forceMove( this.loc );
					amt--;

					if ( ( amt ??0) <= 0 ) {
						break;
					}
				}
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: seed_extractor.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			dynamic dat = null;
			SeedPile P = null;
			Browser popup = null;

			
			if ( this.stat != 0 ) {
				return 0;
			}
			((Mob)user).set_machine( this );
			dat = new ByTable();
			dat += "<b>Stored seeds:</b><br>";

			if ( this.contents.len == 0 ) {
				dat += "<font color='red'>No seeds in storage!</font>";
			} else {
				dat += "<table cellpadding='3' style='text-align:center;'><tr><td width=300>Name</td><td>Lifespan</td><td>Endurance</td><td>Maturation</td><td>Production</td><td>Yield</td><td>Potency</td><td width=180>Stock</td><td width=250>Notes (Mouseover for Info)</td></tr>";

				foreach (dynamic _d in Lang13.Enumerate( this.piles, typeof(SeedPile) )) {
					P = _d;
					
					dat += "<tr><td width=300>" + P.seed.display_name + ( P.seed.roundstart ? "" : " (#" + P.seed.uid + ")" ) + "</td><td>" + P.seed.lifespan + "</td><td>" + P.seed.endurance + "</td><td>" + P.seed.maturation + "</td>";
					dat += "<td>" + P.seed.production + "</td><td>" + P.seed.yield + "</td><td>" + P.seed.potency + "</td><td width=180>";
					dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";seed=" ).item( P.seed.name ).str( ";amt=1'>Vend</a>" ).ToString();
					dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";seed=" ).item( P.seed.name ).str( ";amt=5'>5x</a>" ).ToString();
					dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";seed=" ).item( P.seed.name ).str( ";amt=" ).item( P.amount ).str( "'>All</a>" ).ToString();
					dat += "(" + P.amount + " left)</td><td width=250> ";

					if ( P.seed.biolum != 0 && Lang13.Bool( P.seed.biolum_colour ) ) {
						dat += "<span title=\"This plant is bioluminescent.\" color=" + P.seed.biolum_colour + ">LUM </span>";
					}

					switch ((int)( P.seed.spread )) {
						case 1:
							dat += "<span title=\"This plant is capable of growing beyond the confines of a tray.\">CREEP </span>";
							break;
						case 2:
							dat += "<span title=\"This plant is a robust and vigorous vine that will spread rapidly.\">VINE </span>";
							break;
					}

					switch ((int)( P.seed.carnivorous )) {
						case 1:
							dat += "<span title=\"This plant is carnivorous and will eat tray pests for sustenance.\">CARN </span>";
							break;
						case 2:
							dat += "<span title=\"This plant is carnivorous and poses a significant threat to living things around it.\">HCARN </span>";
							break;
					}

					switch ((int)( P.seed.juicy )) {
						case 1:
							dat += "<span title=\"This plant's fruit is soft-skinned and abudantly juicy\">SPLAT</span>";
							break;
						case 2:
							dat += "<span title=\"This plant's fruit is excesively soft and juicy.\">SLIP </span>";
							break;
					}

					if ( P.seed.immutable > 0 ) {
						dat += "<span title=\"This plant does not possess genetics that are alterable.\">NOMUT </span>";
					}

					if ( P.seed.parasite != 0 ) {
						dat += "<span title=\"This plant is capable of parisitizing and gaining sustenance from tray weeds.\">PARA </span>";
					}

					if ( Lang13.Bool( P.seed.hematophage ) ) {
						dat += "<span title=\"This plant is a highly specialized hematophage that will only draw nutrients from blood.\">BLOOD </span>";
					}

					if ( P.seed.alter_temp != 0 ) {
						dat += "<span title=\"This plant will gradually alter the local room temperature to match it's ideal habitat.\">TEMP </span>";
					}

					if ( P.seed.exude_gasses.len != 0 ) {
						dat += "<span title=\"This plant will exude gas into the environment.\">GAS </span>";
					}

					if ( P.seed.thorny != 0 ) {
						dat += "<span title=\"This plant posesses a cover of sharp thorns.\">THORN </span>";
					}

					if ( P.seed.stinging != 0 ) {
						dat += "<span title=\"This plant posesses a cover of fine stingers capable of releasing chemicals on touch.\">STING </span>";
					}

					if ( P.seed.ligneous != 0 ) {
						dat += "<span title=\"This is a ligneous plant with strong and robust stems.\">WOOD </span>";
					}

					if ( P.seed.teleporting != 0 ) {
						dat += "<span title=\"This plant posesses a high degree of temporal/spatial instability and may cause spontaneous bluespace disruptions.\">TELE </span>";
					}
					dat += "</td>";
				}
				dat += "</table>";
			}
			dat = GlobalFuncs.list2text( dat );
			popup = new Browser( user, "seed_ext", this.name, 1000, 400 );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: seed_extractor.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.interact( a );
			return null;
		}

		// Function from file: seed_extractor.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic P = null;
			int loaded = 0;
			Obj_Item_Seeds G = null;
			dynamic new_seed_type = null;
			dynamic F = null;
			dynamic F2 = null;
			int? produce = null;
			int? i = null;
			Obj_Item_Seeds seeds = null;
			dynamic S = null;
			dynamic F3 = null;
			int t_amount = 0;
			int t_max = 0;

			
			if ( a is Obj_Item_Weapon_Storage_Bag_Plants ) {
				
				if ( !this.hasSpaceCheck( b ) ) {
					return null;
				}
				P = a;
				loaded = 0;

				foreach (dynamic _a in Lang13.Enumerate( P.contents, typeof(Obj_Item_Seeds) )) {
					G = _a;
					
					loaded++;
					this.moveToStorage( G );

					if ( this.contents.len >= 999 ) {
						GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You fill " ).the( this ).item().str( " to the brim.</span>" ).ToString() );
						return null;
					}
				}

				if ( loaded != 0 ) {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You put the seeds from " ).the( a.name ).item().str( " into " ).item( this ).str( ".</span>" ).ToString() );
				} else {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>There are no seeds in " ).the( a.name ).item().str( ".</span>" ).ToString() );
				}
				return null;
			}

			if ( a is Obj_Item_Seeds ) {
				
				if ( !this.hasSpaceCheck( b ) ) {
					return null;
				}
				new ByTable().Set( "force_drop", 1 ).Apply( Lang13.BindFunc( b, "drop_item" ) );
				this.moveToStorage( a );
				GlobalFuncs.to_chat( b, "<span class='notice'>You add " + a + " to " + this.name + ".</span>" );
				this.updateUsrDialog();
				return null;
			}

			if ( a is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown || a is Obj_Item_Weapon_Grown ) {
				new ByTable().Set( 1, a ).Set( "force_drop", 1 ).Apply( Lang13.BindFunc( b, "drop_item" ) );
				new_seed_type = null;

				if ( a is Obj_Item_Weapon_Grown ) {
					F = a;
					new_seed_type = GlobalVars.plant_controller.seeds[F.plantname];
				} else {
					F2 = a;
					new_seed_type = GlobalVars.plant_controller.seeds[F2.plantname];
				}

				if ( Lang13.Bool( new_seed_type ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You extract some seeds from " + a + ".</span>" );
					produce = Rand13.Int( ((int)( this.min_seeds )), ((int)( this.max_seeds )) );
					i = null;
					i = 0;

					while (( i ??0) <= ( produce ??0)) {
						seeds = new Obj_Item_Seeds( GlobalFuncs.get_turf( this ) );
						seeds.seed_type = new_seed_type.name;
						seeds.update_seed();
						i++;
					}
				} else {
					GlobalFuncs.to_chat( b, "" + a + " doesn't seem to have any usable seeds inside it." );
				}
				GlobalFuncs.qdel( a );
			} else if ( a is Obj_Item_Stack_Tile_Grass ) {
				S = a;
				GlobalFuncs.to_chat( b, "<span class='notice'>You extract some seeds from the " + S.name + ".</span>" );
				S.use( 1 );
				new Obj_Item_Seeds_Grassseed( this.loc );
			}

			if ( Lang13.Bool( a ) ) {
				F3 = a;

				if ( Lang13.Bool( F3.nonplant_seed_type ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You extract some seeds from the " + F3.name + ".</span>" );
					new ByTable().Set( 1, a ).Set( "force_drop", 1 ).Apply( Lang13.BindFunc( b, "drop_item" ) );
					t_amount = 0;
					t_max = Rand13.Int( 1, 4 );

					while (t_amount < t_max) {
						Lang13.Call( F3.nonplant_seed_type, this.loc );
						t_amount++;
					}
					GlobalFuncs.qdel( F3 );
				}
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: seed_extractor.dm
		public override dynamic RefreshParts(  ) {
			double B = 0;
			Obj_Item_Weapon_StockParts_Manipulator M = null;
			Obj_Item_Weapon_StockParts_ScanningModule M2 = null;

			B = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				M = _a;
				
				B += ( M.rating - 1 ) * 0.5;
			}
			this.min_seeds = B + 1;
			B = 0;

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_ScanningModule) )) {
				M2 = _b;
				
				B += M2.rating - 1;
			}
			this.max_seeds = B + 4;
			return null;
		}

	}

}