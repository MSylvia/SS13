// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Glass : Obj_Item_Stack_Sheet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "glass sheet";
			this.materials = new ByTable().Set( "$glass", 2000 );
			this.icon_state = "sheet-glass";
		}

		public Obj_Item_Stack_Sheet_Glass ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

		// Function from file: glass.dm
		public bool construct_window( dynamic user = null ) {
			string title = null;
			ByTable directions = null;
			int i = 0;
			Obj_Structure_Window win = null;
			dynamic dir_to_set = null;
			dynamic direction = null;
			bool found = false;
			Obj_Structure_Window WT = null;
			Obj_Structure_Window W = null;
			Obj_Structure_Window_Fulltile W2 = null;

			
			if ( !Lang13.Bool( user ) || !( this != null ) ) {
				return false;
			}

			if ( !( user.loc is Tile ) ) {
				return false;
			}

			if ( !((Mob)user).IsAdvancedToolUser() ) {
				user.WriteMsg( "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return false;
			}

			if ( this.zero_amount() ) {
				return false;
			}
			title = "Sheet-Glass";
			title += new Txt( " (" ).item( this.get_amount() ).str( " sheet" ).s().str( " left)" ).ToString();

			switch ((string)( Interface13.Alert( title, "Would you like full tile glass or one direction?", "One Direction", "Full Window", "Cancel" ) )) {
				case "One Direction":
					
					if ( !( this != null ) ) {
						return true;
					}

					if ( this.loc != user ) {
						return true;
					}
					directions = new ByTable( GlobalVars.cardinal );
					i = 0;

					foreach (dynamic _a in Lang13.Enumerate( user.loc, typeof(Obj_Structure_Window) )) {
						win = _a;
						
						i++;

						if ( i >= 4 ) {
							user.WriteMsg( "<span class='warning'>There are too many windows in this location.</span>" );
							return true;
						}
						directions.Remove( win.dir );

						if ( !GlobalVars.cardinal.Contains( win.ini_dir ) ) {
							user.WriteMsg( "<span class='danger'>Can't let you do that.</span>" );
							return true;
						}
					}
					dir_to_set = 2;

					foreach (dynamic _c in Lang13.Enumerate( new ByTable(new object [] { user.dir, Num13.Rotate( user.dir, 90 ), Num13.Rotate( user.dir, 180 ), Num13.Rotate( user.dir, 270 ) }) )) {
						direction = _c;
						
						found = false;

						foreach (dynamic _b in Lang13.Enumerate( user.loc, typeof(Obj_Structure_Window) )) {
							WT = _b;
							

							if ( WT.dir == direction ) {
								found = true;
							}
						}

						if ( !found ) {
							dir_to_set = direction;
							break;
						}
					}
					W = null;
					W = new Obj_Structure_Window( user.loc, false );
					W.dir = Convert.ToInt32( dir_to_set );
					W.ini_dir = W.dir;
					W.anchored = 0;
					W.air_update_turf( true );
					this.use( 1 );
					W.add_fingerprint( user );
					break;
				case "Full Window":
					
					if ( !( this != null ) ) {
						return true;
					}

					if ( this.loc != user ) {
						return true;
					}

					if ( ( this.get_amount() ??0) < 2 ) {
						user.WriteMsg( "<span class='warning'>You need more glass to do that!</span>" );
						return true;
					}

					if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Window), user.loc ) ) ) {
						user.WriteMsg( "<span class='warning'>There is a window in the way!</span>" );
						return true;
					}
					W2 = null;
					W2 = new Obj_Structure_Window_Fulltile( user.loc, false );
					W2.anchored = 0;
					W2.air_update_turf( true );
					W2.add_fingerprint( user );
					this.use( 2 );
					break;
			}
			return false;
		}

		// Function from file: glass.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic CC = null;
			Obj_Item_Stack_LightW new_tile = null;
			dynamic V = null;
			Obj_Item_Stack_Sheet_Rglass RG = null;
			Obj_Item_Stack_Sheet_Glass G = null;
			bool replace = false;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			this.add_fingerprint( user );

			if ( A is Obj_Item_Stack_CableCoil ) {
				CC = A;

				if ( ( this.get_amount() ??0) < 1 || ( ((Obj_Item_Stack)CC).get_amount() ??0) < 5 ) {
					user.WriteMsg( "<span class='warning>You need five lengths of coil and one sheet of glass to make wired glass!</span>" );
					return null;
				}
				CC.use( 5 );
				this.use( 1 );
				user.WriteMsg( "<span class='notice'>You attach wire to the " + this.name + ".</span>" );
				new_tile = new Obj_Item_Stack_LightW( user.loc );
				new_tile.add_fingerprint( user );
			} else if ( A is Obj_Item_Stack_Rods ) {
				V = A;

				if ( ( ((Obj_Item_Stack)V).get_amount() ??0) >= 1 && ( this.get_amount() ??0) >= 1 ) {
					RG = new Obj_Item_Stack_Sheet_Rglass( user.loc );
					RG.add_fingerprint( user );
					G = this;
					Task13.Source = null;
					replace = ((Mob)user).get_inactive_hand() == G;
					V.use( 1 );
					G.use( 1 );

					if ( !( G != null ) && replace ) {
						((Mob)user).put_in_hands( RG );
					}
				} else {
					user.WriteMsg( "<span class='warning'>You need one rod and one sheet of glass to make reinforced glass!</span>" );
					return null;
				}
			} else {
				return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: glass.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.construct_window( user );
			return null;
		}

	}

}