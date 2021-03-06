// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Constructshell_Large : Obj_Structure_Constructshell {

		public int maxhealth = 200;
		public double health = 200;
		public Image black_overlay = null;
		public int orbs = 0;
		public int orbs_needed = 1;
		public int time_to_win = 1800;
		public int timer_id = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -16;
			this.pixel_y = -16;
			this.icon = "icons/obj/cult_large.dmi";
			this.icon_state = "shell_narsie_grey";
			this.layer = 4.5;
		}

		// Function from file: cult_structures.dm
		public Obj_Structure_Constructshell_Large ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic cult = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( GlobalVars.ticker.mode.name == "cult" ) {
				cult = GlobalVars.ticker.mode;
				this.orbs_needed = Convert.ToInt32( cult.orbs_needed );

				if ( cult.eldergod || cult.large_shell_reference != null && cult.large_shell_reference != this ) {
					GlobalFuncs.qdel( this );
					return;
				}
			} else {
				GlobalFuncs.qdel( this );
				return;
			}
			this.black_overlay = new Image( "icons/obj/cult_large.dmi", "shell_narsie_black" );
			GlobalVars.SSshuttle.emergencyNoEscape = true;
			return;
		}

		// Function from file: cult_structures.dm
		public override double singularity_act( int? current_size = null, Obj_Singularity S = null ) {
			dynamic target = null;

			target = GlobalFuncs.get_edge_target_turf( this, Map13.GetDistance( this, S ) );
			S.throw_at( target, 5, 1 );
			return 0;
		}

		// Function from file: cult_structures.dm
		public override void singularity_pull( Obj_Singularity S = null, int? current_size = null ) {
			return;
		}

		// Function from file: cult_structures.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			return false;
		}

		// Function from file: cult_structures.dm
		public override bool attack_hulk( Mob_Living_Carbon_Human hulk = null, bool? do_attack_animation = null ) {
			GlobalFuncs.playsound( this, "sound/effects/bang.ogg", 50, 1 );
			hulk.visible_message( "<span class='danger'>" + hulk + " smashes " + this + ".</span>", "<span class='danger'>You punch " + this + ".</span>" );
			this.damaged( 5 );
			return false;
		}

		// Function from file: cult_structures.dm
		public override bool mech_melee_attack( Obj_Mecha M = null ) {
			
			if ( M.damtype == "brute" ) {
				GlobalFuncs.playsound( this, "sound/effects/bang.ogg", 50, 1 );
				this.visible_message( "<span class='danger'>" + M.name + " has hit " + this + ".</span>" );
				this.damaged( M.force );
			}
			return false;
		}

		// Function from file: cult_structures.dm
		public override bool attack_animal( Mob_Living user = null ) {
			Mob_Living M = null;

			
			if ( !( user is Mob_Living_SimpleAnimal ) ) {
				return false;
			}
			M = user;
			M.do_attack_animation( this );

			if ( Convert.ToDouble( ((dynamic)M).melee_damage_upper ) <= 0 ) {
				return false;
			}
			this.damaged( ((dynamic)M).melee_damage_upper );
			return false;
		}

		// Function from file: cult_structures.dm
		public override bool attack_alien( dynamic user = null ) {
			((Ent_Dynamic)user).do_attack_animation( this );
			GlobalFuncs.playsound( this, "sound/effects/bang.ogg", 50, 1 );
			((Ent_Static)user).visible_message( "<span class='danger'>" + user + " smashes against " + this + " with its claws.</span>", "<span class='danger'>You smash against " + this + " with your claws.</span>" );
			this.damaged( 15 );
			return false;
		}

		// Function from file: cult_structures.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( Lang13.Bool( P.damage ) ) {
				GlobalFuncs.playsound( this, "sound/effects/bang.ogg", 50, 1 );
				this.visible_message( "<span class='danger'>" + this + " was hit by " + P + ".</span>" );
				this.damaged( P.damage );
			}
			return null;
		}

		// Function from file: cult_structures.dm
		public void summon_narnar(  ) {
			dynamic cult_mode = null;
			dynamic target_turf = null;

			
			if ( GlobalVars.ticker.mode.name != "cult" ) {
				this.visible_message( new Txt( "<span class='warning'>" ).The( this ).item().str( " glows brightly once, then falls dark. It looks strangely dull and lifeless...</span>" ).ToString() );
				GlobalFuncs.log_game( "Summon Nar-Sie rune failed - gametype is not cult" );
				return;
			}
			cult_mode = GlobalVars.ticker.mode;

			if ( cult_mode.eldergod ) {
				return;
			}
			Game13.WriteMsg( "sound/effects/dimensional_rend.ogg" );
			Game13.WriteMsg( "<span class='cultitalic'><b>Rip... <span class='big'>Rrrip...</span> <span class='reallybig'>RRRRRRRRRR--</span></b></span>" );
			target_turf = GlobalFuncs.get_turf( this );
			Task13.Schedule( 40, (Task13.Closure)(() => {
				new Obj_Singularity_Narsie_Large( target_turf );
				cult_mode.eldergod = true;

				if ( this != null ) {
					GlobalFuncs.qdel( this );
				}
				return;
			}));
			return;
		}

		// Function from file: cult_structures.dm
		public void damaged( dynamic damage = null ) {
			this.health -= Convert.ToDouble( damage );

			if ( this.health <= 0 ) {
				new Obj_Item_Stack_Sheet_Plasteel( GlobalFuncs.get_turf( this ) );
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: cult_structures.dm
		public void start_takeover(  ) {
			dynamic A = null;
			dynamic locname = null;

			this.anchored = 1;
			this.overlays.Remove( this.black_overlay );
			this.icon_state = "shell_narsie_active";
			Icon13.Flick( "shell_narsie_activation", this );
			GlobalFuncs.set_security_level( "delta" );
			A = GlobalFuncs.get_area( this );
			locname = Lang13.Initial( A, "name" );
			GlobalFuncs.priority_announce( "Figments from an eldritch god have begun pouring into " + locname + " from an unknown dimension. Eliminate its vessel before it reaches a critical point.", "Central Command Higher Dimensions Affairs" );
			this.timer_id = GlobalFuncs.addtimer( this, "summon_narnar", this.time_to_win );
			return;
		}

		// Function from file: cult_structures.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic T = null;

			
			if ( A is Obj_Item_SummoningOrb && this.orbs < this.orbs_needed ) {
				
				if ( !GlobalFuncs.iscultist( user ) ) {
					return null;
				}
				T = GlobalFuncs.get_turf( user );

				if ( Lang13.Bool( T.z ) != true ) {
					user.WriteMsg( "<span class='cultlarge'>You shouldn't do this here. Go back.</span>" );
					return null;
				}
				this.visible_message( new Txt( "<span class='cult'>" ).The( this ).item().str( " glows.</span>" ).ToString() );
				this.orbs++;
				GlobalFuncs.qdel( A );
				this.update_icon();

				if ( this.orbs >= this.orbs_needed ) {
					this.start_takeover();
				}
				return null;
			}

			if ( Lang13.Bool( A.flags & 4 ) || !Lang13.Bool( A.force ) ) {
				return null;
			}
			this.add_fingerprint( user );
			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).do_attack_animation( this );
			GlobalFuncs.playsound( this, "sound/weapons/smash.ogg", 50, 1 );
			this.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " has hit " ).the( this ).item().str( " with " ).item( A ).str( ".</span>" ).ToString() );

			if ( A.damtype == "fire" || A.damtype == "brute" ) {
				this.damaged( A.force );
			}
			return null;
		}

		// Function from file: cult_structures.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			int new_alpha = 0;

			new_alpha = Num13.Floor( this.orbs / this.orbs_needed * 255 );

			if ( new_alpha != 0 ) {
				this.overlays.Remove( this.black_overlay );
				this.black_overlay.alpha = new_alpha;
				this.overlays.Add( this.black_overlay );
			}
			return false;
		}

		// Function from file: cult_structures.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "<span class='cult'>You see a number of round holes on the surface of the shell. They number " + this.orbs_needed + ", and " + ( this.orbs != 0 ? ((dynamic)( this.orbs )) : ((dynamic)( "none" )) ) + " of them " + ( this.orbs > 1 ? "are" : "is" ) + " filled.</span>" );
			return 0;
		}

		// Function from file: cult_structures.dm
		public override dynamic Destroy(  ) {
			bool go_to_red = false;
			dynamic cult = null;

			go_to_red = true;

			if ( GlobalVars.ticker.mode.name == "cult" ) {
				cult = GlobalVars.ticker.mode;
				cult.large_shell_reference = null;

				if ( cult.eldergod ) {
					go_to_red = false;
				}
			}
			this.black_overlay = null;

			if ( this.timer_id != 0 ) {
				GlobalFuncs.deltimer( this.timer_id );

				if ( go_to_red ) {
					GlobalFuncs.priority_announce( "The extra-dimensional flow has ceased. All personnel should return to their routine activities.", "Central Command Higher Dimensions Affairs" );

					if ( GlobalFuncs.get_security_level() == "delta" ) {
						GlobalFuncs.set_security_level( "red" );
					}
				}
			}
			GlobalVars.SSshuttle.emergencyNoEscape = false;

			if ( GlobalVars.SSshuttle.emergency.mode == 4 ) {
				GlobalVars.SSshuttle.emergency.mode = 3;
				GlobalVars.SSshuttle.emergency.timer = Game13.time;
			}
			base.Destroy();
			return null;
		}

	}

}