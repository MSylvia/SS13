// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Sleeper : Obj_Machinery {

		public dynamic efficiency = 1;
		public dynamic min_health = -25;
		public ByTable available_chems = null;
		public ByTable possible_chems = new ByTable(new object [] { 
											new ByTable(new object [] { "epinephrine", "morphine", "salbutamol", "bicaridine", "kelotane" }), 
											new ByTable(new object [] { "oculine" }), 
											new ByTable(new object [] { "antitoxin", "mutadone", "mannitol", "pen_acid" }), 
											new ByTable(new object [] { "omnizine" })
										 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.state_open = 1;
			this.icon = "icons/obj/Cryogenic2.dmi";
			this.icon_state = "sleeper-open";
		}

		// Function from file: Sleeper.dm
		public Obj_Machinery_Sleeper ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Manipulator( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_ConsoleScreen( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_ConsoleScreen( null ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( null, 1 ) );
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Sleeper( null ) );
			this.RefreshParts();
			return;
		}

		// Function from file: Sleeper.dm
		public bool chem_allowed( dynamic chem = null ) {
			bool amount = false;
			bool health = false;

			
			if ( !Lang13.Bool( this.occupant ) ) {
				return false;
			}
			amount = ( ((Reagents)this.occupant.reagents).get_reagent_amount( chem ) ?1:0) + 10 <= Convert.ToDouble( this.efficiency * 20 );
			health = Convert.ToDouble( this.occupant.health ) > Convert.ToDouble( this.min_health ) || chem == "epinephrine";
			return amount && health;
		}

		// Function from file: Sleeper.dm
		public int? inject_chem( string chem = null ) {
			
			if ( this.available_chems.Contains( chem ) && this.chem_allowed( chem ) ) {
				this.occupant.reagents.add_reagent( chem, 10 );
				return GlobalVars.TRUE;
			}
			return null;
		}

		// Function from file: Sleeper.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			string chem = null;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) ) {
				return _default;
			}

			switch ((string)( action )) {
				case "door":
					
					if ( Lang13.Bool( this.state_open ) ) {
						this.close_machine();
					} else {
						this.open_machine();
					}
					_default = GlobalVars.TRUE;
					break;
				case "inject":
					chem = _params["chem"];

					if ( !this.is_operational() || !Lang13.Bool( this.occupant ) ) {
						return _default;
					}

					if ( Convert.ToDouble( this.occupant.health ) < Convert.ToDouble( this.min_health ) && chem != "epinephrine" ) {
						return _default;
					}

					if ( Lang13.Bool( this.inject_chem( chem ) ) ) {
						_default = GlobalVars.TRUE;
					}
					break;
			}
			return _default;
		}

		// Function from file: Sleeper.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;
			dynamic chem = null;
			dynamic R = null;
			Reagent R2 = null;

			data = new ByTable();
			data["occupied"] = ( Lang13.Bool( this.occupant ) ? true : false );
			data["open"] = this.state_open;
			data["chems"] = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.available_chems )) {
				chem = _a;
				
				R = GlobalVars.chemical_reagents_list[chem];
				data["chems"] += new ByTable(new object [] { new ByTable().Set( "name", R.name ).Set( "id", R.id ).Set( "allowed", this.chem_allowed( chem ) ) });
			}
			data["occupant"] = new ByTable();

			if ( Lang13.Bool( this.occupant ) ) {
				data["occupant"]["name"] = this.occupant.name;
				data["occupant"]["stat"] = this.occupant.stat;
				data["occupant"]["health"] = this.occupant.health;
				data["occupant"]["maxHealth"] = this.occupant.maxHealth;
				data["occupant"]["minHealth"] = GlobalVars.config.health_threshold_dead;
				data["occupant"]["bruteLoss"] = ((Mob_Living)this.occupant).getBruteLoss();
				data["occupant"]["oxyLoss"] = ((Mob_Living)this.occupant).getOxyLoss();
				data["occupant"]["toxLoss"] = ((Mob_Living)this.occupant).getToxLoss();
				data["occupant"]["fireLoss"] = ((Mob_Living)this.occupant).getFireLoss();
				data["occupant"]["cloneLoss"] = ((Mob_Living)this.occupant).getCloneLoss();
				data["occupant"]["brainLoss"] = ((Mob_Living)this.occupant).getBrainLoss();
				data["occupant"]["reagents"] = new ByTable();

				if ( this.occupant.reagents.reagent_list.len != 0 ) {
					
					foreach (dynamic _b in Lang13.Enumerate( this.occupant.reagents.reagent_list, typeof(Reagent) )) {
						R2 = _b;
						
						data["occupant"]["reagents"] += new ByTable(new object [] { new ByTable().Set( "name", R2.name ).Set( "volume", R2.volume ) });
					}
				}
			}
			return data;
		}

		// Function from file: Sleeper.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.notcontained_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "sleeper", this.name, 375, 550, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: Sleeper.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( !Lang13.Bool( this.state_open ) && !Lang13.Bool( this.occupant ) ) {
				
				if ( this.default_deconstruction_screwdriver( user, "sleeper-o", "sleeper", A ) ) {
					return null;
				}
			}

			if ( this.default_change_direction_wrench( user, A ) ) {
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( this.default_pry_open( A ) ) {
				return null;
			}

			if ( this.default_deconstruction_crowbar( A ) ) {
				return null;
			}
			return null;
		}

		// Function from file: Sleeper.dm
		public override bool MouseDrop_T( Ent_Static dropping = null, Mob user = null ) {
			
			if ( user.stat != 0 || Lang13.Bool( user.lying ) || !this.Adjacent( user ) || !user.Adjacent( dropping ) || !( dropping is Mob_Living_Carbon ) ) {
				return false;
			}
			this.close_machine( dropping );
			return false;
		}

		// Function from file: Sleeper.dm
		public override bool blob_act( dynamic severity = null ) {
			dynamic T = null;
			Ent_Dynamic A = null;

			
			if ( Rand13.PercentChance( 75 ) ) {
				T = GlobalFuncs.get_turf( this );

				foreach (dynamic _a in Lang13.Enumerate( this, typeof(Ent_Dynamic) )) {
					A = _a;
					
					A.forceMove( T );
					A.blob_act();
				}
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: Sleeper.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( this.is_operational() && Lang13.Bool( this.occupant ) ) {
				this.open_machine();
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: Sleeper.dm
		public override bool attack_animal( Mob_Living user = null ) {
			
			if ( Lang13.Bool( ((dynamic)user).environment_smash ) ) {
				user.do_attack_animation( this );
				this.visible_message( "<span class='danger'>" + user.name + " smashes " + this + " apart!</span>" );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: Sleeper.dm
		public override dynamic close_machine( Ent_Static target = null ) {
			
			if ( ( target == null || target is Mob ) && Lang13.Bool( this.state_open ) && !Lang13.Bool( this.panel_open ) ) {
				base.close_machine( target );
			}
			return null;
		}

		// Function from file: Sleeper.dm
		public override bool open_machine( int? dump = null ) {
			
			if ( !Lang13.Bool( this.state_open ) && !Lang13.Bool( this.panel_open ) ) {
				base.open_machine( dump );
			}
			return false;
		}

		// Function from file: Sleeper.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			this.container_resist();
			return false;
		}

		// Function from file: Sleeper.dm
		public override void container_resist( Mob user = null ) {
			this.visible_message( "<span class='notice'>" + this.occupant + " emerges from " + this + "!</span>", "<span class='notice'>You climb out of " + this + "!</span>" );
			this.open_machine();
			return;
		}

		// Function from file: Sleeper.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( Lang13.Bool( this.state_open ) ) {
				this.icon_state = "sleeper-open";
			} else {
				this.icon_state = "sleeper";
			}
			return false;
		}

		// Function from file: Sleeper.dm
		public override void RefreshParts(  ) {
			dynamic E = null;
			Obj_Item_Weapon_StockParts_MatterBin B = null;
			dynamic I = null;
			Obj_Item_Weapon_StockParts_Manipulator M = null;
			double i = 0;

			
			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MatterBin) )) {
				B = _a;
				
				E += B.rating;
			}
			I = null;

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				M = _b;
				
				I += M.rating;
			}
            
        
			this.efficiency = Lang13.Initial( this, "efficiency" ) * E;
			this.min_health = Lang13.Initial( this, "min_health" ) * E;
			this.available_chems = new ByTable();

            // TODO If parts list is empty, what the hell do we do? Nothing? -Pdan
            if (I == null)
            {
                return;
            }

            foreach (dynamic _c in Lang13.IterateRange( 1, I )) {
				i = _c;
				
				this.available_chems.Or( this.possible_chems[i] );
			}
			return;
		}

	}

}