// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_TankDispenser : Obj_Structure {

		public int oxygentanks = 10;
		public int plasmatanks = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "dispenser";
		}

		// Function from file: tank_dispenser.dm
		public Obj_Structure_TankDispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;
			double i2 = 0;

			
			foreach (dynamic _a in Lang13.IterateRange( 1, this.oxygentanks )) {
				i = _a;
				
				new Obj_Item_Weapon_Tank_Internals_Oxygen( this );
			}

			foreach (dynamic _b in Lang13.IterateRange( 1, this.plasmatanks )) {
				i2 = _b;
				
				new Obj_Item_Weapon_Tank_Internals_Plasma( this );
			}
			this.update_icon();
			return;
		}

		// Function from file: tank_dispenser.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			dynamic tank = null;
			dynamic tank2 = null;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) ) {
				return _default;
			}

			switch ((string)( action )) {
				case "plasma":
					tank = Lang13.FindIn( typeof(Obj_Item_Weapon_Tank_Internals_Plasma), this );

					if ( Lang13.Bool( tank ) ) {
						Task13.User.put_in_hands( tank );
						this.plasmatanks--;
					}
					_default = GlobalVars.TRUE;
					break;
				case "oxygen":
					tank2 = Lang13.FindIn( typeof(Obj_Item_Weapon_Tank_Internals_Oxygen), this );

					if ( Lang13.Bool( tank2 ) ) {
						Task13.User.put_in_hands( tank2 );
						this.oxygentanks--;
					}
					_default = GlobalVars.TRUE;
					break;
			}
			this.update_icon();
			return _default;
		}

		// Function from file: tank_dispenser.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;

			data = new ByTable();
			data["oxygen"] = this.oxygentanks;
			data["plasma"] = this.plasmatanks;
			return data;
		}

		// Function from file: tank_dispenser.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.physical_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "tank_dispenser", this.name, 275, 100, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: tank_dispenser.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			int? full = null;

			
			if ( A is Obj_Item_Weapon_Tank_Internals_Plasma ) {
				
				if ( this.plasmatanks < 10 ) {
					this.plasmatanks++;
				} else {
					full = GlobalVars.TRUE;
				}
			} else if ( A is Obj_Item_Weapon_Tank_Internals_Oxygen ) {
				
				if ( this.oxygentanks < 10 ) {
					this.oxygentanks++;
				} else {
					full = GlobalVars.TRUE;
				}
			} else {
				user.WriteMsg( "<span class='notice'>" + A + " does not fit into " + this + ".</span>" );
				return null;
			}

			if ( Lang13.Bool( full ) ) {
				user.WriteMsg( "<span class='notice'>" + this + " can't hold anymore of " + A + ".</span>" );
				return null;
			}

			if ( !Lang13.Bool( user.drop_item() ) ) {
				return null;
			}
			A.loc = this;
			user.WriteMsg( "<span class='notice'>You put " + A + " in " + this + ".</span>" );
			this.update_icon();
			return null;
		}

		// Function from file: tank_dispenser.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();

			dynamic _a = this.oxygentanks; // Was a switch-case, sorry for the mess.
			if ( 1<=_a&&_a<=3 ) {
				this.overlays.Add( "oxygen-" + this.oxygentanks );
			} else if ( 4<=_a&&_a<=10 ) {
				this.overlays.Add( "oxygen-4" );
			}

			dynamic _b = this.plasmatanks; // Was a switch-case, sorry for the mess.
			if ( 1<=_b&&_b<=4 ) {
				this.overlays.Add( "plasma-" + this.plasmatanks );
			} else if ( 5<=_b&&_b<=10 ) {
				this.overlays.Add( "plasma-5" );
			}
			return false;
		}

	}

}