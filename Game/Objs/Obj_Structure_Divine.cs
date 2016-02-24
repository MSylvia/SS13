// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine : Obj_Structure {

		public bool constructable = true;
		public bool trap = false;
		public dynamic metal_cost = 0;
		public dynamic glass_cost = 0;
		public dynamic lesser_gem_cost = 0;
		public dynamic greater_gem_cost = 0;
		public Mob_Camera_God deity = null;
		public string side = "neutral";
		public double health = 100;
		public double maxhealth = 100;
		public bool autocolours = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/hand_of_god_structures.dmi";
		}

		// Function from file: structures.dm
		public Obj_Structure_Divine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: structures.dm
		public override bool attack_animal( Mob_Living user = null ) {
			int damage = 0;

			
			if ( !( user != null ) ) {
				return false;
			}
			this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " has been attacked by " ).the( user ).item().str( "!</span>" ).ToString() );
			damage = Rand13.Int( Convert.ToInt32( ((dynamic)user).melee_damage_lower ), Convert.ToInt32( ((dynamic)user).melee_damage_upper ) );

			if ( !( damage != 0 ) ) {
				return false;
			}
			this.health = Num13.MaxInt( 0, ((int)( this.health - damage )) );
			this.healthcheck();
			return false;
		}

		// Function from file: structures.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( !Lang13.Bool( P ) ) {
				return 0;
			}

			if ( P.damage_type == "brute" || P.damage_type == "fire" ) {
				this.health = Num13.MaxInt( 0, ((int)( this.health - Convert.ToDouble( P.damage ) )) );
				this.healthcheck();
			}
			return null;
		}

		// Function from file: structures.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic G = null;

			
			if ( !Lang13.Bool( A ) || Lang13.Bool( A.flags & 128 ) ) {
				return 0;
			}

			if ( A is Obj_Item_Weapon_Godstaff ) {
				
				if ( !GlobalFuncs.is_handofgod_cultist( user ) ) {
					user.WriteMsg( "<span class='notice'>You're not quite sure what the hell you're even doing.</span>" );
					return null;
				}
				G = A;

				if ( Lang13.Bool( G.god ) && this.deity != G.god ) {
					this.assign_deity( G.god, GlobalVars.TRUE );
					this.visible_message( new Txt( "<span class='boldnotice'>" ).The( this ).item().str( " has been captured by " ).item( user ).str( "!</span>" ).ToString() );
				}
				return null;
			}
			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).do_attack_animation( this );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), A.hitsound, 50, 1 );
			this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " has been attacked with " ).the( A ).item().item( ( Lang13.Bool( user ) ? " by " + user : "." ) ).str( "!</span>" ).ToString() );
			this.health = Num13.MaxInt( 0, ((int)( this.health - Convert.ToDouble( A.force ) )) );
			this.healthcheck();
			return null;
		}

		// Function from file: structures.dm
		public override dynamic Destroy(  ) {
			
			if ( this.deity != null ) {
				this.deity.structures.Remove( this );
			}
			return base.Destroy();
		}

		// Function from file: structures.dm
		public virtual bool assign_deity( Mob_Camera_God new_deity = null, int? alert_old_deity = null ) {
			alert_old_deity = alert_old_deity ?? GlobalVars.TRUE;

			
			if ( !( new_deity != null ) ) {
				return false;
			}

			if ( this.deity != null ) {
				
				if ( Lang13.Bool( alert_old_deity ) ) {
					this.deity.WriteMsg( "<span class='danger'><B>Your " + this.name + " was captured by " + new_deity + "'s cult!</B></span>" );
				}
				this.deity.structures.Remove( this );
			}
			this.deity = new_deity;
			this.deity.structures.Or( this );
			this.side = this.deity.side;
			this.update_icons();
			return true;
		}

		// Function from file: structures.dm
		public virtual void healthcheck(  ) {
			
			if ( !( this.health != 0 ) ) {
				this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " was destroyed!</span>" ).ToString() );
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: structures.dm
		public virtual void update_icons(  ) {
			
			if ( this.autocolours ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "-" + this.side;
			}
			return;
		}

	}

}