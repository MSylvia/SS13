// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Recycler : Obj_Machinery {

		public bool safety_mode = false;
		public bool grinding = false;
		public string icon_name = "grinder-o";
		public bool blood = false;
		public int eat_dir = 8;
		public int amount_produced = 1;
		public MaterialContainer materials = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/recycling.dmi";
			this.icon_state = "grinder-o0";
			this.layer = 5;
		}

		// Function from file: recycler.dm
		public Obj_Machinery_Recycler ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Recycler( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Manipulator( null ) );
			this.materials = new MaterialContainer( this, new ByTable().Set( "$metal", 1 ).Set( "$glass", 1 ).Set( "$plasma", 1 ).Set( "$silver", 1 ).Set( "$gold", 1 ).Set( "$diamond", 1 ).Set( "$uranium", 1 ).Set( "$bananium", 1 ) );
			this.RefreshParts();
			this.update_icon();
			return;
		}

		// Function from file: recycler.dm
		public void eat( dynamic L = null ) {
			bool gib = false;
			Obj_Item I = null;

			L.loc = this.loc;

			if ( L is Mob_Living_Silicon ) {
				GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );
			} else {
				GlobalFuncs.playsound( this.loc, "sound/effects/splat.ogg", 50, 1 );
			}
			gib = true;

			if ( L is Mob_Living_Carbon ) {
				gib = false;

				if ( Lang13.Bool( L.stat ) == false ) {
					((Ent_Dynamic)L).say( "ARRRRRRRRRRRGH!!!" );
				}
				this.add_blood( L );
			}

			if ( !this.blood && !( L is Mob_Living_Silicon ) ) {
				this.blood = true;
				this.update_icon();
			}

			foreach (dynamic _a in Lang13.Enumerate( ((Mob)L).get_equipped_items(), typeof(Obj_Item) )) {
				I = _a;
				

				if ( ((Mob)L).unEquip( I ) ) {
					this.recycle( I, false );
				}
			}
			((Mob)L).Paralyse( 5 );

			if ( gib || this.emagged == 2 ) {
				((Mob)L).gib();
			} else if ( this.emagged == 1 ) {
				((Mob_Living)L).adjustBruteLoss( 1000 );
			}
			return;
		}

		// Function from file: recycler.dm
		public void stop( dynamic L = null ) {
			GlobalFuncs.playsound( this.loc, "sound/machines/buzz-sigh.ogg", 50, 0 );
			this.safety_mode = true;
			this.update_icon();
			L.loc = this.loc;
			Task13.Schedule( GlobalVars.SAFETY_COOLDOWN, (Task13.Closure)(() => {
				GlobalFuncs.playsound( this.loc, "sound/machines/ping.ogg", 50, 0 );
				this.safety_mode = false;
				this.update_icon();
				return;
			}));
			return;
		}

		// Function from file: recycler.dm
		public void recycle( dynamic I = null, bool? sound = null ) {
			sound = sound ?? true;

			double material_amount = 0;

			I.loc = this.loc;

			if ( !( I is Obj_Item ) ) {
				return;
			}

			if ( sound == true ) {
				GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );
			}
			material_amount = this.materials.get_item_material_amount( I );

			if ( !( material_amount != 0 ) ) {
				GlobalFuncs.qdel( I );
				return;
			}
			this.materials.insert_item( I, this.amount_produced / 100 );
			GlobalFuncs.qdel( I );
			this.materials.retrieve_all();
			return;
		}

		// Function from file: recycler.dm
		public override bool Bumped( dynamic AM = null ) {
			int move_dir = 0;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return false;
			}

			if ( !Lang13.Bool( this.anchored ) ) {
				return false;
			}

			if ( this.safety_mode ) {
				return false;
			}
			move_dir = Map13.GetDistance( this.loc, AM.loc );

			if ( move_dir == this.eat_dir ) {
				
				if ( AM is Mob_Living ) {
					
					if ( Lang13.Bool( this.emagged ) ) {
						this.eat( AM );
					} else {
						this.stop( AM );
					}
				} else if ( AM is Obj_Item ) {
					this.recycle( AM );
				} else {
					GlobalFuncs.playsound( this.loc, "sound/machines/buzz-sigh.ogg", 50, 0 );
					AM.loc = this.loc;
				}
			}
			return false;
		}

		// Function from file: recycler.dm
		public override dynamic Bump( Ent_Static Obstacle = null, dynamic yes = null ) {
			base.Bump( Obstacle, (object)(yes) );

			if ( Obstacle != null ) {
				this.Bumped( Obstacle );
			}
			return null;
		}

		// Function from file: recycler.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			bool is_powered = false;

			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			is_powered = !( ( this.stat & 3 ) != 0 );

			if ( this.safety_mode ) {
				is_powered = false;
			}
			this.icon_state = this.icon_name + ( "" + is_powered ) + ( "" + ( this.blood ? "bld" : "" ) );
			return false;
		}

		// Function from file: recycler.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( !Lang13.Bool( this.emagged ) ) {
				this.emagged = 1;

				if ( this.safety_mode ) {
					this.safety_mode = false;
					this.update_icon();
				}
				GlobalFuncs.playsound( this.loc, "sparks", 75, 1, -1 );
				user.WriteMsg( "<span class='notice'>You use the cryptographic sequencer on the " + this.name + ".</span>" );
			}
			return false;
		}

		// Function from file: recycler.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.default_deconstruction_screwdriver( user, "grinder-oOpen", "grinder-o0", A ) ) {
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( this.default_pry_open( A ) ) {
				return null;
			}

			if ( this.default_unfasten_wrench( user, A ) ) {
				return null;
			}
			this.default_deconstruction_crowbar( A );
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: recycler.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

		// Function from file: recycler.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "The power light is " + ( ( this.stat & 2 ) != 0 ? "off" : "on" ) + "." );
			user.WriteMsg( "The safety-mode light is " + ( this.safety_mode ? "on" : "off" ) + "." );
			user.WriteMsg( "The safety-sensors status light is " + ( Lang13.Bool( this.emagged ) ? "off" : "on" ) + "." );
			return 0;
		}

		// Function from file: recycler.dm
		public override void RefreshParts(  ) {
			dynamic amt_made = null;
			dynamic mat_mod = null;
			Obj_Item_Weapon_StockParts_MatterBin B = null;
			Obj_Item_Weapon_StockParts_Manipulator M = null;

			amt_made = 0;
			mat_mod = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MatterBin) )) {
				B = _a;
				
				mat_mod = B.rating * 2;
			}
			mat_mod *= 50000;

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				M = _b;
				
				amt_made = M.rating * 25;
			}
			this.materials.max_amount = mat_mod;
			this.amount_produced = Num13.MinInt( 100, Convert.ToInt32( amt_made ) );
			return;
		}

	}

}