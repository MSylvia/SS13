// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_PortGen_Pacman : Obj_Machinery_Power_PortGen {

		public double sheets = 0;
		public dynamic max_sheets = 100;
		public string sheet_name = "";
		public Type sheet_path = typeof(Obj_Item_Stack_Sheet_Mineral_Plasma);
		public string board_path = "/obj/item/weapon/circuitboard/pacman";
		public double sheet_left = 0;
		public int time_per_sheet = 260;
		public double current_heat = 0;

		// Function from file: port_gen.dm
		public Obj_Machinery_Power_PortGen_Pacman ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic sheet = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( this ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MicroLaser( this ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( this, 1 ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( this, 1 ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Capacitor( this ) );
			this.component_parts.Add( Lang13.Call( this.board_path, this ) );
			sheet = Lang13.Call( this.sheet_path, null );
			this.sheet_name = sheet.name;
			this.RefreshParts();
			return;
		}

		// Function from file: port_gen.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["action"] ) ) {
				
				if ( href_list["action"] == "enable" ) {
					
					if ( !this.active && this.HasFuel() && !this.crit_fail ) {
						this.active = true;
						this.icon_state = "portgen1";
						this.updateUsrDialog();
					}
				}

				if ( href_list["action"] == "disable" ) {
					
					if ( this.active ) {
						this.active = false;
						this.icon_state = "portgen0";
						this.updateUsrDialog();
					}
				}

				if ( href_list["action"] == "eject" ) {
					
					if ( !this.active ) {
						this.DropFuel();
						this.updateUsrDialog();
					}
				}

				if ( href_list["action"] == "lower_power" ) {
					
					if ( this.power_output > 1 ) {
						this.power_output--;
						this.updateUsrDialog();
					}
				}

				if ( href_list["action"] == "higher_power" ) {
					
					if ( this.power_output < 4 || Lang13.Bool( this.emagged ) ) {
						this.power_output++;
						this.updateUsrDialog();
					}
				}

				if ( href_list["action"] == "close" ) {
					Interface13.Browse( Task13.User, null, "window=port_gen" );
					Task13.User.unset_machine();
				}
			}
			return null;
		}

		// Function from file: port_gen.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			double stack_percent = 0;

			
			if ( Map13.GetDistance( this, user ) > 1 ) {
				
				if ( !( user is Mob_Living_Silicon_Ai ) ) {
					((Mob)user).unset_machine();
					Interface13.Browse( user, null, "window=port_gen" );
					return null;
				}
			}
			((Mob)user).set_machine( this );
			dat = "<b>" + this.name + "</b><br>";

			if ( this.active ) {
				dat += new Txt( "Generator: <A href='?src=" ).Ref( this ).str( ";action=disable'>On</A><br>" ).ToString();
			} else {
				dat += new Txt( "Generator: <A href='?src=" ).Ref( this ).str( ";action=enable'>Off</A><br>" ).ToString();
			}
			dat += new Txt().item( GlobalFuncs.capitalize( this.sheet_name ) ).str( ": " ).item( this.sheets ).str( " - <A href='?src=" ).Ref( this ).str( ";action=eject'>Eject</A><br>" ).ToString();
			stack_percent = Num13.Round( this.sheet_left * 100, 1 );
			dat += "Current stack: " + stack_percent + "% <br>";
			dat += new Txt( "Power output: <A href='?src=" ).Ref( this ).str( ";action=lower_power'>-</A> " ).item( this.power_gen * this.power_output ).str( " <A href='?src=" ).Ref( this ).str( ";action=higher_power'>+</A><br>" ).ToString();
			dat += "Power current: " + ( this.powernet == null ? "Unconnected" : "" + this.avail() ) + "<br>";
			dat += "Heat: " + this.current_heat + "<br>";
			dat += new Txt( "<br><A href='?src=" ).Ref( this ).str( ";action=close'>Close</A>" ).ToString();
			Interface13.Browse( user, "" + dat, "window=port_gen" );
			GlobalFuncs.onclose( user, "port_gen" );
			return null;
		}

		// Function from file: port_gen.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.interact( a );
			return null;
		}

		// Function from file: port_gen.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.interact( user );
			return null;
		}

		// Function from file: port_gen.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			base.attack_hand( (object)(a), b, c );

			if ( !Lang13.Bool( this.anchored ) ) {
				return null;
			}
			this.interact( a );
			return null;
		}

		// Function from file: port_gen.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( !Lang13.Bool( this.emagged ) ) {
				this.emagged = 1;
				this.emp_act( 1 );
			}
			return false;
		}

		// Function from file: port_gen.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic addstack = null;
			int amount = 0;

			
			if ( Lang13.Bool( ((dynamic)this.sheet_path).IsInstanceOfType( A ) ) ) {
				addstack = A;
				amount = Num13.MinInt( Convert.ToInt32( this.max_sheets - this.sheets ), Convert.ToInt32( addstack.amount ) );

				if ( amount < 1 ) {
					user.WriteMsg( "<span class='notice'>The " + this.name + " is full!</span>" );
					return null;
				}
				user.WriteMsg( "<span class='notice'>You add " + amount + " sheets to the " + this.name + ".</span>" );
				this.sheets += amount;
				addstack.use( amount );
				this.updateUsrDialog();
				return null;
			} else if ( !this.active ) {
				
				if ( this.exchange_parts( user, A ) ) {
					return null;
				}

				if ( A is Obj_Item_Weapon_Wrench ) {
					
					if ( !Lang13.Bool( this.anchored ) && !this.isinspace() ) {
						this.connect_to_network();
						user.WriteMsg( "<span class='notice'>You secure the generator to the floor.</span>" );
						this.anchored = 1;
					} else if ( Lang13.Bool( this.anchored ) ) {
						this.disconnect_from_network();
						user.WriteMsg( "<span class='notice'>You unsecure the generator from the floor.</span>" );
						this.anchored = 0;
					}
					GlobalFuncs.playsound( this.loc, "sound/items/Deconstruct.ogg", 50, 1 );
				} else if ( A is Obj_Item_Weapon_Screwdriver ) {
					this.panel_open = !Lang13.Bool( this.panel_open ) ?1:0;
					GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );

					if ( Lang13.Bool( this.panel_open ) ) {
						user.WriteMsg( "<span class='notice'>You open the access panel.</span>" );
					} else {
						user.WriteMsg( "<span class='notice'>You close the access panel.</span>" );
					}
				} else if ( A is Obj_Item_Weapon_Crowbar && Lang13.Bool( this.panel_open ) ) {
					this.default_deconstruction_crowbar( A );
				}
			}
			return null;
		}

		// Function from file: port_gen.dm
		public virtual void overheat(  ) {
			GlobalFuncs.explosion( this.loc, 2, 5, 2, -1 );
			return;
		}

		// Function from file: port_gen.dm
		public override void handleInactive(  ) {
			
			if ( this.current_heat > 0 ) {
				this.current_heat = Num13.MaxInt( ((int)( this.current_heat - 2 )), 0 );
				this.updateDialog();
			}
			return;
		}

		// Function from file: port_gen.dm
		public override void UseFuel(  ) {
			double needed_sheets = 0;
			int temp = 0;
			double lower_limit = 0;
			double upper_limit = 0;
			double bias = 0;

			needed_sheets = 1 / ( this.time_per_sheet * this.consumption / this.power_output );
			temp = Num13.MinInt( ((int)( needed_sheets )), ((int)( this.sheet_left )) );
			needed_sheets -= temp;
			this.sheet_left -= temp;
			this.sheets -= Num13.Floor( needed_sheets );
			needed_sheets -= Num13.Floor( needed_sheets );

			if ( this.sheet_left <= 0 && this.sheets > 0 ) {
				this.sheet_left = 1 - needed_sheets;
				this.sheets--;
			}
			lower_limit = this.power_output * 10 + 56;
			upper_limit = this.power_output * 10 + 76;
			bias = 0;

			if ( this.power_output > 4 ) {
				upper_limit = 400;
				bias = this.power_output - this.consumption * ( 4 - this.consumption );
			}

			if ( this.current_heat < lower_limit ) {
				this.current_heat += 4 - this.consumption;
			} else {
				this.current_heat += Rand13.Int( ((int)( bias + -7 )), ((int)( bias + 7 )) );

				if ( this.current_heat < lower_limit ) {
					this.current_heat = lower_limit;
				}

				if ( this.current_heat > upper_limit ) {
					this.current_heat = upper_limit;
				}
			}

			if ( this.current_heat > 300 ) {
				this.overheat();
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: port_gen.dm
		public override void DropFuel(  ) {
			int fail_safe = 0;
			dynamic S = null;
			int amount = 0;

			
			if ( this.sheets != 0 ) {
				fail_safe = 0;

				while (this.sheets > 0 && fail_safe < 100) {
					fail_safe += 1;
					S = Lang13.Call( this.sheet_path, this.loc );
					amount = Num13.MinInt( ((int)( this.sheets )), Convert.ToInt32( S.max_amount ) );
					S.amount = amount;
					this.sheets -= amount;
				}
			}
			return;
		}

		// Function from file: port_gen.dm
		public override bool HasFuel(  ) {
			
			if ( this.sheets >= 1 / ( this.time_per_sheet / this.power_output ) - this.sheet_left ) {
				return true;
			}
			return false;
		}

		// Function from file: port_gen.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "<span class='notice'>The generator has " + this.sheets + " units of " + this.sheet_name + " fuel left, producing " + this.power_gen + " per cycle.</span>" );

			if ( this.crit_fail ) {
				user.WriteMsg( "<span class='danger'>The generator seems to have broken down.</span>" );
			}
			return 0;
		}

		// Function from file: port_gen.dm
		public override void RefreshParts(  ) {
			double temp_rating = 0;
			double consumption_coeff = 0;
			Obj_Item_Weapon_StockParts SP = null;

			temp_rating = 0;
			consumption_coeff = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts) )) {
				SP = _a;
				

				if ( SP is Obj_Item_Weapon_StockParts_MatterBin ) {
					this.max_sheets = SP.rating * SP.rating * 50;
				} else if ( SP is Obj_Item_Weapon_StockParts_Capacitor ) {
					temp_rating += Convert.ToDouble( SP.rating );
				} else {
					consumption_coeff += Convert.ToDouble( SP.rating );
				}
			}
			this.power_gen = Num13.Floor( Convert.ToDouble( Lang13.Initial( this, "power_gen" ) * temp_rating * 2 ) );
			this.consumption = consumption_coeff;
			return;
		}

		// Function from file: port_gen.dm
		public override dynamic Destroy(  ) {
			this.DropFuel();
			return base.Destroy();
		}

		// Function from file: port_gen.dm
		public override void initialize(  ) {
			base.initialize();

			if ( Lang13.Bool( this.anchored ) ) {
				this.connect_to_network();
			}
			return;
		}

	}

}