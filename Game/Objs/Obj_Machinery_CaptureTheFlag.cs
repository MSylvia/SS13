// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_CaptureTheFlag : Obj_Machinery {

		public string team = "white";
		public int points = 0;
		public int points_to_win = 3;
		public int respawn_cooldown = 150;
		public int control_points = 0;
		public int control_points_to_win = 180;
		public ByTable team_members = new ByTable();
		public int? ctf_enabled = 0;
		public Type ctf_gear = typeof(Outfit_Ctf);
		public Type instagib_gear = typeof(Outfit_Ctf_Instagib);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/device.dmi";
			this.icon_state = "syndbeacon";
		}

		// Function from file: capture_the_flag.dm
		public Obj_Machinery_CaptureTheFlag ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.poi_list.Or( this );
			return;
		}

		// Function from file: capture_the_flag.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic flag = null;
			dynamic M = null;
			dynamic mob_area = null;

			
			if ( A is Obj_Item_Weapon_Twohanded_Required_Ctf ) {
				flag = A;

				if ( flag.team != this.team ) {
					((Mob)user).unEquip( flag );
					flag.loc = GlobalFuncs.get_turf( flag.reset );
					this.points++;

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
						M = _a;
						
						mob_area = GlobalFuncs.get_area( M );

						if ( mob_area is Zone_Ctf ) {
							M.WriteMsg( new Txt( "<span class='userdanger'>" ).item( user.real_name ).str( " has captured " ).the( flag ).item().str( ", scoring a point for " ).item( this.team ).str( " team! They now have " ).item( this.points ).str( "/" ).item( this.points_to_win ).str( " points!</span>" ).ToString() );
						}
					}
				}

				if ( this.points >= this.points_to_win ) {
					this.victory();
				}
			}
			return null;
		}

		// Function from file: capture_the_flag.dm
		public void instagib_mode(  ) {
			Obj_Machinery_CaptureTheFlag CTF = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_CaptureTheFlag) )) {
				CTF = _a;
				

				if ( CTF.ctf_enabled == GlobalVars.TRUE ) {
					CTF.ctf_gear = CTF.instagib_gear;
					CTF.respawn_cooldown = 50;
				}
			}
			return;
		}

		// Function from file: capture_the_flag.dm
		public void victory(  ) {
			dynamic M = null;
			dynamic mob_area = null;
			Obj_Item_Weapon_Twohanded_Required_Ctf W = null;
			Obj_Machinery_ControlPoint control = null;
			Obj_Machinery_CaptureTheFlag CTF = null;

			
			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.mob_list )) {
				M = _b;
				
				mob_area = GlobalFuncs.get_area( M );

				if ( mob_area is Zone_Ctf ) {
					M.WriteMsg( "<span class='narsie'>" + this.team + " team wins!</span>" );
					M.WriteMsg( "<span class='userdanger'>The game has been reset! Teams have been cleared. The machines will be active again in 30 seconds.</span>" );

					foreach (dynamic _a in Lang13.Enumerate( M, typeof(Obj_Item_Weapon_Twohanded_Required_Ctf) )) {
						W = _a;
						
						((Mob)M).unEquip( W );
					}
					((Mob)M).dust();
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_ControlPoint) )) {
				control = _c;
				
				control.icon_state = "dominator";
				control.controlling = null;
			}

			foreach (dynamic _d in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_CaptureTheFlag) )) {
				CTF = _d;
				

				if ( CTF.ctf_enabled == GlobalVars.TRUE ) {
					CTF.points = 0;
					CTF.control_points = 0;
					CTF.ctf_enabled = GlobalVars.FALSE;
					CTF.team_members = new ByTable();
					Task13.Schedule( 300, (Task13.Closure)(() => {
						CTF.ctf_enabled = GlobalVars.TRUE;
						return;
					}));
				}
			}
			return;
		}

		// Function from file: capture_the_flag.dm
		public void spawn_team_member( Client new_team_member = null ) {
			Mob_Living_Carbon_Human M = null;

			M = new Mob_Living_Carbon_Human( GlobalFuncs.get_turf( this ) );
			new_team_member.prefs.copy_to( M );
			M.key = new_team_member.key;
			M.faction += this.team;
			M.equipOutfit( this.ctf_gear );
			return;
		}

		// Function from file: capture_the_flag.dm
		public void dust_old( Mob user = null ) {
			
			if ( user.mind != null && Lang13.Bool( user.mind.current ) && Convert.ToInt32( user.mind.current.z ) == this.z ) {
				new Obj_Item_AmmoBox_Magazine_Recharge_Ctf( GlobalFuncs.get_turf( user.mind.current ) );
				new Obj_Item_AmmoBox_Magazine_Recharge_Ctf( GlobalFuncs.get_turf( user.mind.current ) );
				((Mob)user.mind.current).dust();
			}
			return;
		}

		// Function from file: capture_the_flag.dm
		public override void attack_ghost( Mob user = null ) {
			Client new_team_member = null;
			Obj_Machinery_CaptureTheFlag CTF = null;
			Client new_team_member2 = null;

			
			if ( this.ctf_enabled == GlobalVars.FALSE ) {
				return;
			}

			if ( GlobalVars.ticker.current_state != 3 ) {
				return;
			}

			if ( this.team_members.Contains( user.ckey ) ) {
				
				if ( Lang13.Bool( user.mind.current ) && user.mind.current.timeofdeath + this.respawn_cooldown > Game13.time ) {
					user.WriteMsg( "It must be more than " + this.respawn_cooldown / 10 + " seconds from your last death to respawn!" );
					return;
				}
				new_team_member = user.client;
				this.dust_old( user );
				this.spawn_team_member( new_team_member );
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_CaptureTheFlag) )) {
				CTF = _a;
				

				if ( CTF == this || CTF.ctf_enabled == GlobalVars.FALSE ) {
					continue;
				}

				if ( CTF.team_members.Contains( user.ckey ) ) {
					user.WriteMsg( "No switching teams while the round is going!" );
					return;
				}

				if ( CTF.team_members.len < this.team_members.len ) {
					user.WriteMsg( "" + this.team + " has more team members than " + CTF.team + ". Try joining " + CTF.team + " to even things up." );
					return;
				}
			}
			this.team_members.Or( user.ckey );
			new_team_member2 = user.client;
			this.dust_old( user );
			this.spawn_team_member( new_team_member2 );
			return;
		}

		// Function from file: capture_the_flag.dm
		public override dynamic Destroy(  ) {
			GlobalVars.poi_list.Remove( this );
			base.Destroy();
			return null;
		}

	}

}