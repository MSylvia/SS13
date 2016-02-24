// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Displaycase : Obj_Structure {

		public dynamic health = 30;
		public bool destroyed = false;
		public dynamic showpiece = null;
		public bool alert = false;
		public bool open = false;
		public dynamic electronics = null;
		public Type start_showpiece_type = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/obj/stationobjs.dmi";
			this.icon_state = "glassbox0";
		}

		// Function from file: displaycase.dm
		public Obj_Structure_Displaycase ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.start_showpiece_type != null ) {
				this.showpiece = Lang13.Call( this.start_showpiece_type, this );
			}
			this.update_icon();
			return;
		}

		// Function from file: displaycase.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			((Mob)a).changeNext_move( 8 );

			if ( Lang13.Bool( this.showpiece ) && ( this.destroyed || this.open ) ) {
				this.dump();
				a.WriteMsg( "<span class='notice'>You deactivate the hover field built into the case.</span>" );
				this.add_fingerprint( a );
				this.update_icon();
				return null;
			} else {
				((Ent_Static)a).visible_message( "<span class='danger'>" + a + " kicks the display case.</span>", "<span class='notice'>You kick the display case.</span>" );
				this.health -= 2;
				this.healthcheck();
				return null;
			}
		}

		// Function from file: displaycase.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: displaycase.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic G = null;

			
			if ( A is Obj_Item_Weapon_Card && Lang13.Bool( this.electronics ) && !this.destroyed && this.allowed( user ) ) {
				user.WriteMsg( "<span class='notice'>You " + ( this.open ? "close" : "open" ) + " the " + this + "</span>" );
				this.open = !this.open;
				this.update_icon();
				return null;
			}

			if ( !this.alert && A is Obj_Item_Weapon_Crowbar ) {
				
				if ( this.destroyed && !Lang13.Bool( this.showpiece ) ) {
					user.WriteMsg( "<span class='notice'>You remove the destroyed case</span>" );
					GlobalFuncs.qdel( this );
					return null;
				}
				user.WriteMsg( "<span class='notice'>You start to " + ( this.open ? "close" : "open" ) + " the " + this + "</span>" );

				if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
					user.WriteMsg( "<span class='notice'>You " + ( this.open ? "close" : "open" ) + " the " + this + "</span>" );
					this.open = !this.open;
					this.update_icon();
				}
			} else if ( this.open && !Lang13.Bool( this.showpiece ) ) {
				
				if ( ((Mob)user).unEquip( A ) ) {
					A.loc = this;
					this.showpiece = A;
					user.WriteMsg( "<span class='notice'>You put " + A + " on display</span>" );
					this.update_icon();
				}
			} else if ( A is Obj_Item_Stack_Sheet_Glass && this.destroyed ) {
				G = A;

				if ( ( ((Obj_Item_Stack)G).get_amount() ??0) < 2 ) {
					user.WriteMsg( "<span class='warning'>You need two glass sheets to fix the case!</span>" );
					return null;
				}
				user.WriteMsg( "<span class='notice'>You start fixing the " + this + "...</span>" );

				if ( GlobalFuncs.do_after( user, 20, null, this ) ) {
					G.use( 2 );
					this.destroyed = false;
					this.health = Lang13.Initial( this, "health" );
					this.update_icon();
				}
			} else {
				((Mob)user).changeNext_move( 8 );
				this.health -= A.force;
				this.healthcheck();
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: displaycase.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Icon I = null;
			Icon S = null;

			
			if ( this.open ) {
				I = new Icon( "icons/obj/stationobjs.dmi", "glassbox_open" );
			} else {
				I = new Icon( "icons/obj/stationobjs.dmi", "glassbox0" );
			}

			if ( this.destroyed ) {
				I = new Icon( "icons/obj/stationobjs.dmi", "glassboxb0" );
			}

			if ( Lang13.Bool( this.showpiece ) ) {
				S = this.get_flat_icon_directional( this.showpiece );
				S.Scale( 17, 17 );
				I.Blend( S, 6, 8, 8 );
			}
			this.icon = I;
			return false;
		}

		// Function from file: displaycase.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 75 ) ) {
				new Obj_Item_Weapon_Shard( this.loc );
				this.dump();
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: displaycase.dm
		public Icon get_flat_icon_directional( dynamic A = null ) {
			Icon I = null;
			dynamic old_dir = null;

			
			if ( this.is_directional( A ) ) {
				I = GlobalFuncs.getFlatIcon( A );
			} else {
				old_dir = A.dir;
				A.dir = 2;
				I = GlobalFuncs.getFlatIcon( A );
				A.dir = old_dir;
			}
			return I;
		}

		// Function from file: displaycase.dm
		public bool is_directional( dynamic A = null ) {
			
			try {
				GlobalFuncs.getFlatIcon( A, 4 );
			} catch (Exception __) {
				return false;
			}
			return true;
		}

		// Function from file: displaycase.dm
		public void healthcheck(  ) {
			dynamic alarmed = null;

			
			if ( Convert.ToDouble( this.health ) <= 0 ) {
				
				if ( !this.destroyed ) {
					this.density = false;
					this.destroyed = true;
					new Obj_Item_Weapon_Shard( this.loc );
					GlobalFuncs.playsound( this, "shatter", 70, 1 );
					this.update_icon();

					if ( this.alert ) {
						alarmed = GlobalFuncs.get_area( this );
						((Zone)alarmed).burglaralert( this );
						GlobalFuncs.playsound( this, "sound/effects/alert.ogg", 50, 1 );
					}
				}
			} else {
				GlobalFuncs.playsound( this.loc, "sound/effects/Glasshit.ogg", 75, 1 );
			}
			return;
		}

		// Function from file: displaycase.dm
		public void dump(  ) {
			
			if ( Lang13.Bool( this.showpiece ) ) {
				this.showpiece.loc = this.loc;
				this.showpiece = null;
			}
			return;
		}

		// Function from file: displaycase.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( P.damage_type == "brute" || P.damage_type == "fire" ) {
				this.health -= P.damage;
			}
			base.bullet_act( (object)(P), (object)(def_zone) );
			this.healthcheck();
			return null;
		}

		// Function from file: displaycase.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( Lang13.Bool( this.showpiece ) ) {
				user.WriteMsg( "<span class='notice'>There's " + this.showpiece + " inside.</span>" );
			}

			if ( this.alert ) {
				user.WriteMsg( "<span class='notice'>Hooked up with an anti-theft system.</span>" );
			}
			return 0;
		}

		// Function from file: displaycase.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					new Obj_Item_Weapon_Shard( this.loc );
					this.dump();
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.health -= 15;
						this.healthcheck();
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.health -= 5;
						this.healthcheck();
					}
					break;
			}
			return false;
		}

	}

}