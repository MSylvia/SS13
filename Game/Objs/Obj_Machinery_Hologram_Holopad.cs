// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Hologram_Holopad : Obj_Machinery_Hologram {

		public ByTable masters = new ByTable();
		public int last_request = 0;
		public double holo_range = 5;
		public string temp = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 16;
			this.languages = 9;
			this.icon_state = "holopad0";
			this.layer = 2.1;
		}

		// Function from file: hologram.dm
		public Obj_Machinery_Hologram_Holopad ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Holopad( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Capacitor( null ) );
			this.RefreshParts();
			return;
		}

		// Function from file: hologram.dm
		public override dynamic Destroy(  ) {
			Mob_Living_Silicon_Ai master = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.masters, typeof(Mob_Living_Silicon_Ai) )) {
				master = _a;
				
				this.clear_holo( master );
			}
			return base.Destroy();
		}

		// Function from file: hologram.dm
		public override int? process( dynamic seconds = null ) {
			Mob_Living_Silicon_Ai master = null;
			dynamic holo_area = null;
			dynamic eye_area = null;

			
			if ( this.masters.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.masters, typeof(Mob_Living_Silicon_Ai) )) {
					master = _a;
					

					if ( master != null && !( master.stat != 0 ) && master.client != null && master.eyeobj != null ) {
						
						if ( !( ( this.stat & 2 ) != 0 ) ) {
							
							if ( GlobalVars.HOLOPAD_MODE == 4 && Map13.GetDistance( master.eyeobj, this ) <= this.holo_range ) {
								return 1;
							} else if ( GlobalVars.HOLOPAD_MODE == 6 ) {
								holo_area = GlobalFuncs.get_area( this );
								eye_area = GlobalFuncs.get_area( master.eyeobj );

								if ( holo_area.master.related.Contains( eye_area ) ) {
									return 1;
								}
							}
						}
					}
					this.clear_holo( master );
				}
			}
			return 1;
		}

		// Function from file: hologram.dm
		public override string Hear( string message = null, dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null, ByTable spans = null ) {
			Mob_Living_Silicon_Ai master = null;

			
			if ( Lang13.Bool( speaker ) && this.masters.len != 0 && !Lang13.Bool( radio_freq ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.masters, typeof(Mob_Living_Silicon_Ai) )) {
					master = _a;
					

					if ( Lang13.Bool( this.masters[master] ) && speaker != master ) {
						master.relay_speech( message, speaker, message_langs, raw_message, radio_freq, spans );
					}
				}
			}
			return null;
		}

		// Function from file: hologram.dm
		public bool move_hologram( Mob_Living_Silicon_Ai user = null ) {
			Ent_Static H = null;

			
			if ( Lang13.Bool( this.masters[user] ) ) {
				Map13.StepTowards( this.masters[user], user.eyeobj, 0 );
				H = this.masters[user];
				H.loc = GlobalFuncs.get_turf( user.eyeobj );
				this.masters[user] = H;
			}
			return true;
		}

		// Function from file: hologram.dm
		public bool clear_holo( dynamic user = null ) {
			
			if ( user.current == this ) {
				user.current = null;
			}
			GlobalFuncs.qdel( this.masters[user] );
			this.masters.Remove( user );
			this.use_power = Num13.MaxInt( 1, this.use_power - 2 );

			if ( !( this.masters.len != 0 ) ) {
				this.SetLuminosity( 0 );
				this.icon_state = "holopad0";
				this.use_power = 1;
			}
			return true;
		}

		// Function from file: hologram.dm
		public bool create_holo( dynamic A = null, Ent_Static T = null ) {
			T = T ?? this.loc;

			Obj_Effect_Overlay_HoloPadHologram h = null;

			h = new Obj_Effect_Overlay_HoloPadHologram( T );
			h.icon = A.holo_icon;
			h.mouse_opacity = 0;
			h.layer = GlobalVars.FLY_LAYER;
			h.anchored = 1;
			h.name = "" + A.name + " (Hologram)";
			h.SetLuminosity( 2 );
			this.masters[A] = h;
			this.SetLuminosity( 2 );
			this.icon_state = "holopad1";
			A.current = this;
			this.use_power += 2;
			return true;
		}

		// Function from file: hologram.dm
		public void activate_holo( dynamic user = null ) {
			
			if ( !( ( this.stat & 2 ) != 0 ) && user.eyeobj.loc == this.loc ) {
				
				if ( user.current is Obj_Machinery_Hologram_Holopad ) {
					user.WriteMsg( "<span class='danger'>ERROR:</span> ÿ\"Image feed in progress." );
					return;
				}
				this.create_holo( user );
				this.visible_message( "A holographic image of " + user + " flicks to life right before your eyes!" );
			} else {
				user.WriteMsg( "<span class='danger'>ERROR:</span> ÿ\"Unable to project hologram." );
			}
			return;
		}

		// Function from file: hologram.dm
		public override dynamic attack_ai( dynamic user = null ) {
			
			if ( !( user is Mob_Living_Silicon_Ai ) ) {
				return null;
			}

			if ( user.eyeobj.loc != this.loc ) {
				((Mob_Camera_AiEye)user.eyeobj).setLoc( GlobalFuncs.get_turf( this ) );
			} else if ( !Lang13.Bool( this.masters[user] ) ) {
				this.activate_holo( user );
			} else {
				this.clear_holo( user );
			}
			return null;
		}

		// Function from file: hologram.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic area = null;
			Mob_Living_Silicon_Ai AI = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["AIrequest"] ) ) {
				
				if ( this.last_request + 200 < Game13.time ) {
					this.last_request = Game13.time;
					this.temp = "You requested an AI's presence.<BR>";
					this.temp += new Txt( "<A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A>" ).ToString();
					area = GlobalFuncs.get_area( this );

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_Silicon_Ai) )) {
						AI = _a;
						

						if ( !( AI.client != null ) ) {
							continue;
						}
						AI.WriteMsg( new Txt( "<span class='info'>Your presence is requested at <a href='?src=" ).Ref( AI ).str( ";jumptoholopad=" ).Ref( this ).str( "'>" ).the( area ).item().str( "</a>.</span>" ).ToString() );
					}
				} else {
					this.temp = "A request for AI presence was already sent recently.<BR>";
					this.temp += new Txt( "<A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A>" ).ToString();
				}
			} else if ( Lang13.Bool( href_list["mainmenu"] ) ) {
				this.temp = "";
			}
			this.updateDialog();
			this.add_fingerprint( Task13.User );
			return null;
		}

		// Function from file: hologram.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			Browser popup = null;

			
			if ( !( user is Mob_Living_Carbon_Human ) ) {
				return null;
			}

			if ( Lang13.Bool( user.stat ) || ( this.stat & 3 ) != 0 ) {
				return null;
			}
			((Mob)user).set_machine( this );

			if ( Lang13.Bool( this.temp ) ) {
				dat = this.temp;
			} else {
				dat = new Txt( "<A href='?src=" ).Ref( this ).str( ";AIrequest=1'>request an AI's presence.</A>" ).ToString();
			}
			popup = new Browser( user, "holopad", this.name, 300, 130 );
			popup.set_content( dat );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open();
			return null;
		}

		// Function from file: hologram.dm
		public override bool AltClick( Mob user = null ) {
			this.interact( user );
			return false;
		}

		// Function from file: hologram.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.default_deconstruction_screwdriver( user, "holopad_open", "holopad0", A ) ) {
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
			return null;
		}

		// Function from file: hologram.dm
		public override void RefreshParts(  ) {
			double holograph_range = 0;
			Obj_Item_Weapon_StockParts_Capacitor B = null;

			holograph_range = 4;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Capacitor) )) {
				B = _a;
				
				holograph_range += Convert.ToDouble( B.rating );
			}
			this.holo_range = holograph_range;
			return;
		}

	}

}