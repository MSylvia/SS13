// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Bot_Medbot : Obj_Machinery_Bot {

		public int stunned = 0;
		public ByTable botcard_access = new ByTable(new object [] { 5 });
		public dynamic reagent_glass = null;
		public string skin = null;
		public int frustration = 0;
		public dynamic path = new ByTable();
		public Mob_Living_Carbon patient = null;
		public dynamic oldpatient = null;
		public dynamic oldloc = null;
		public int last_found = 0;
		public int last_newpatient_speak = 0;
		public bool currently_healing = false;
		public double? injection_amount = 15;
		public double heal_threshold = 10;
		public bool use_beaker = false;
		public string treatment_brute = "tricordrazine";
		public string treatment_oxy = "tricordrazine";
		public string treatment_fire = "tricordrazine";
		public string treatment_tox = "tricordrazine";
		public string treatment_virus = "spaceacillin";
		public bool declare_treatment = false;
		public bool shut_up = false;
		public bool declare_crit = true;
		public bool declare_cooldown = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 20;
			this.maxhealth = 20;
			this.req_access = new ByTable(new object [] { 5 });
			this.bot_type = 5;
			this.icon_state = "medibot0";
			this.layer = 5;
		}

		// Function from file: medbot.dm
		public Obj_Machinery_Bot_Medbot ( dynamic loc = null ) : base( (object)(loc) ) {
			Job_Doctor J = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "medibot" + this.on;
			Task13.Schedule( 4, (Task13.Closure)(() => {
				
				if ( Lang13.Bool( this.skin ) ) {
					this.overlays.Add( new Image( "icons/obj/aibots.dmi", "medskin_" + this.skin ) );
				}
				this.botcard = new Obj_Item_Weapon_Card_Id( this );

				if ( this.botcard_access == null || this.botcard_access.len < 1 ) {
					J = new Job_Doctor();
					this.botcard.access = J.get_access();
				} else {
					this.botcard.access = this.botcard_access;
				}
				return;
			}));
			return;
		}

		// Function from file: medbot.dm
		public override void declare(  ) {
			dynamic location = null;

			
			if ( this.declare_cooldown ) {
				return;
			}
			location = GlobalFuncs.get_area( this );
			this.declare_message = new Txt( "<span class='info'>" ).icon( this ).str( " Medical emergency! A patient is in critical condition at " ).item( location ).str( "!</span>" ).ToString();
			base.declare();
			this.declare_cooldown = true;
			Task13.Schedule( 100, (Task13.Closure)(() => {
				this.declare_cooldown = false;
				return;
			}));
			return;
		}

		// Function from file: medbot.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			Obj_Machinery_Door D = null;

			
			if ( Obstacle is Obj_Machinery_Door && !( this.botcard == null ) ) {
				D = (Obj_Machinery_Door)Obstacle;

				if ( !( D is Obj_Machinery_Door_Firedoor ) && D.check_access( this.botcard ) ) {
					((dynamic)D).open();
					this.frustration = 0;
				}
			} else if ( Obstacle is Mob_Living && !Lang13.Bool( this.anchored ) ) {
				this.loc = Obstacle.loc;
				this.frustration = 0;
			}
			return null;
		}

		// Function from file: medbot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			Effect_Effect_System_SparkSpread s = null;

			this.on = false;
			this.visible_message( "<span class='danger'>" + this + " blows apart!</span>", 1 );
			Tsec = GlobalFuncs.get_turf( this );
			new Obj_Item_Weapon_Storage_Firstaid( Tsec );
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );
			new Obj_Item_Device_Healthanalyzer( Tsec );

			if ( Lang13.Bool( this.reagent_glass ) ) {
				this.reagent_glass.loc = Tsec;
				this.reagent_glass = null;
			}

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_RobotParts_LArm( Tsec );
			}
			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: medbot.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( Proj.flag == "taser" ) {
				this.stunned = Num13.MinInt( this.stunned + 10, 20 );
			}
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			return null;
		}

		// Function from file: medbot.dm
		public void speak( dynamic message = null ) {
			
			if ( !this.on || !Lang13.Bool( message ) ) {
				return;
			}
			this.visible_message( "" + this + " beeps, \"" + message + "\"", null, null, "" + this + " beeps, \"" + Rand13.Pick(new object [] { "FEED ME HUMANS", "LET THE BLOOD FLOW", "BLOOD FOR THE BLOOD GOD", "I SPREAD DEATH AND DESTRUCTION", "EXTERMINATE", "I HATE YOU!", "SURRENDER TO YOUR MACHINE OVERLORDS", "FEED ME SHITTERS" }) + "\"" );
			return;
		}

		// Function from file: medbot.dm
		public void medicate_patient( Mob_Living_Carbon C = null ) {
			dynamic death_message = null;
			string reagent_id = null;
			bool virus = false;
			Disease D = null;
			dynamic message = null;

			
			if ( !this.on ) {
				return;
			}

			if ( !( C is Mob_Living_Carbon ) ) {
				this.oldpatient = this.patient;
				this.patient = null;
				this.currently_healing = false;
				this.last_found = Game13.time;
				return;
			}

			if ( C.stat == 2 ) {
				death_message = Rand13.Pick(new object [] { "No! NO!", "Live, damnit! LIVE!", "I...I've never lost a patient before. Not today, I mean." });
				this.speak( death_message );
				this.oldpatient = this.patient;
				this.patient = null;
				this.currently_healing = false;
				this.last_found = Game13.time;
				return;
			}
			reagent_id = null;

			if ( this.use_beaker && Lang13.Bool( this.reagent_glass ) && Lang13.Bool( this.reagent_glass.reagents.total_volume ) ) {
				reagent_id = "internal_beaker";
			}

			if ( this.emagged == 2 ) {
				reagent_id = "toxin";
			}
			virus = false;

			foreach (dynamic _a in Lang13.Enumerate( C.viruses, typeof(Disease) )) {
				D = _a;
				
				virus = true;
			}

			if ( !Lang13.Bool( reagent_id ) && virus ) {
				
				if ( !((Reagents)C.reagents).has_reagent( this.treatment_virus ) ) {
					reagent_id = this.treatment_virus;
				}
			}

			if ( !Lang13.Bool( reagent_id ) && C.getBruteLoss() >= this.heal_threshold ) {
				
				if ( !((Reagents)C.reagents).has_reagent( this.treatment_brute ) ) {
					reagent_id = this.treatment_brute;
				}
			}

			if ( !Lang13.Bool( reagent_id ) && Convert.ToDouble( C.getOxyLoss() ) >= this.heal_threshold + 15 ) {
				
				if ( !((Reagents)C.reagents).has_reagent( this.treatment_oxy ) ) {
					reagent_id = this.treatment_oxy;
				}
			}

			if ( !Lang13.Bool( reagent_id ) && C.getFireLoss() >= this.heal_threshold ) {
				
				if ( !((Reagents)C.reagents).has_reagent( this.treatment_fire ) ) {
					reagent_id = this.treatment_fire;
				}
			}

			if ( !Lang13.Bool( reagent_id ) && Convert.ToDouble( C.getToxLoss() ) >= this.heal_threshold ) {
				
				if ( !((Reagents)C.reagents).has_reagent( this.treatment_tox ) ) {
					reagent_id = this.treatment_tox;
				}
			}

			if ( !Lang13.Bool( reagent_id ) ) {
				this.oldpatient = this.patient;
				this.patient = null;
				this.currently_healing = false;
				this.last_found = Game13.time;
				message = Rand13.Pick(new object [] { "All patched up!", "An apple a day keeps me away.", "Feel better soon!" });
				this.speak( message );
				return;
			} else {
				this.icon_state = "medibots";
				this.visible_message( "<span class='danger'>" + this + " is trying to inject " + this.patient + "!</span>" );
				Task13.Schedule( 30, (Task13.Closure)(() => {
					
					if ( Map13.GetDistance( this, this.patient ) <= 1 && this.on ) {
						
						if ( reagent_id == "internal_beaker" && Lang13.Bool( this.reagent_glass ) && Lang13.Bool( this.reagent_glass.reagents.total_volume ) ) {
							((Reagents)this.reagent_glass.reagents).trans_to( this.patient, this.injection_amount );
							((Reagents)this.reagent_glass.reagents).reaction( this.patient, 2 );
						} else {
							((Reagents)this.patient.reagents).add_reagent( reagent_id, this.injection_amount );
						}
						this.visible_message( "<span class='danger'>" + this + " injects " + this.patient + " with the syringe!</span>" );
					}
					this.icon_state = "medibot" + this.on;
					this.currently_healing = false;
					return;
					return;
				}));
			}
			reagent_id = null;
			return;
		}

		// Function from file: medbot.dm
		public bool assess_patient( Mob_Living_Carbon C = null ) {
			Reagent R = null;
			Disease D = null;

			
			if ( C.stat == 2 ) {
				return false;
			}

			if ( C.suiciding == true ) {
				return false;
			}

			if ( this.emagged == 2 ) {
				return true;
			}

			if ( this.declare_crit && Convert.ToDouble( C.health ) <= 0 ) {
				this.declare();
			}

			if ( Lang13.Bool( this.reagent_glass ) && this.use_beaker && ( C.getBruteLoss() >= this.heal_threshold || Convert.ToDouble( C.getToxLoss() ) >= this.heal_threshold || Convert.ToDouble( C.getToxLoss() ) >= this.heal_threshold || Convert.ToDouble( C.getOxyLoss() ) >= this.heal_threshold + 15 ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.reagent_glass.reagents.reagent_list, typeof(Reagent) )) {
					R = _a;
					

					if ( !((Reagents)C.reagents).has_reagent( R ) ) {
						return true;
					}
					continue;
				}
			}

			if ( C.getBruteLoss() >= this.heal_threshold && !((Reagents)C.reagents).has_reagent( this.treatment_brute ) ) {
				return true;
			}

			if ( Convert.ToDouble( C.getOxyLoss() ) >= this.heal_threshold + 15 && !((Reagents)C.reagents).has_reagent( this.treatment_oxy ) ) {
				return true;
			}

			if ( C.getFireLoss() >= this.heal_threshold && !((Reagents)C.reagents).has_reagent( this.treatment_fire ) ) {
				return true;
			}

			if ( Convert.ToDouble( C.getToxLoss() ) >= this.heal_threshold && !((Reagents)C.reagents).has_reagent( this.treatment_tox ) ) {
				return true;
			}

			foreach (dynamic _b in Lang13.Enumerate( C.viruses, typeof(Disease) )) {
				D = _b;
				

				if ( ( D.stage ??0) > 1 || D.spread_type == 5 ) {
					
					if ( !((Reagents)C.reagents).has_reagent( this.treatment_virus ) ) {
						return true;
					}
				}
			}
			return false;
		}

		// Function from file: medbot.dm
		public override dynamic process(  ) {
			dynamic message = null;
			Mob_Living_Carbon C = null;
			dynamic message2 = null;
			dynamic location = null;

			
			if ( !this.on ) {
				this.stunned = 0;
				return null;
			}

			if ( this.stunned != 0 ) {
				this.icon_state = "medibota";
				this.stunned--;
				this.oldpatient = this.patient;
				this.patient = null;
				this.currently_healing = false;

				if ( this.stunned <= 0 ) {
					this.icon_state = "medibot" + this.on;
					this.stunned = 0;
				}
				return null;
			}

			if ( this.frustration > 8 ) {
				this.oldpatient = this.patient;
				this.patient = null;
				this.currently_healing = false;
				this.last_found = Game13.time;
				this.path = new ByTable();
			}

			if ( !( this.patient != null ) ) {
				
				if ( !this.shut_up && Rand13.PercentChance( 1 ) ) {
					message = Rand13.Pick(new object [] { "Radar, put a mask on!", "There's always a catch, and it's the best there is.", "I knew it, I should've been a plastic surgeon.", "What kind of medbay is this? Everyone's dropping like dead flies.", "Delicious!" });
					this.speak( message );
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Mob_Living_Carbon) )) {
					C = _a;
					

					if ( C.stat == 2 || !( C is Mob_Living_Carbon_Human ) ) {
						continue;
					}

					if ( C == this.oldpatient && Game13.time < this.last_found + 100 ) {
						continue;
					}

					if ( this.assess_patient( C ) ) {
						this.patient = C;
						this.oldpatient = C;
						this.last_found = Game13.time;
						Task13.Schedule( 0, (Task13.Closure)(() => {
							
							if ( this.last_newpatient_speak + 100 < Game13.time ) {
								message2 = Rand13.Pick(new object [] { "Hey, you! Hold on, I'm coming.", "Wait! I want to help!", "You appear to be injured!" });
								this.speak( message2 );
								this.last_newpatient_speak = Game13.time;

								if ( this.declare_treatment ) {
									location = GlobalFuncs.get_area( this );
									GlobalFuncs.broadcast_medical_hud_message( "" + this.name + " is treating <b>" + C + "</b> in <b>" + location + "</b>", this );
								}
							}
							this.visible_message( "<b>" + this + "</b> points at " + C.name + "!" );
							return;
						}));
						break;
					} else {
						continue;
					}
				}
			}

			if ( !Lang13.Bool( this.path ) ) {
				this.path = new ByTable();
			}

			if ( this.patient != null && Map13.GetDistance( this, this.patient ) <= 1 ) {
				
				if ( !this.currently_healing ) {
					this.currently_healing = true;
					this.frustration = 0;
					this.medicate_patient( this.patient );
				}
				return null;
			} else if ( this.patient != null && this.path.len != 0 && Map13.GetDistance( this.patient, this.path[this.path.len] ) > 2 ) {
				this.path = new ByTable();
				this.currently_healing = false;
				this.last_found = Game13.time;
			}

			if ( this.patient != null && this.path.len == 0 && Map13.GetDistance( this, this.patient ) > 1 ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.path = GlobalFuncs.AStar( this.loc, GlobalFuncs.get_turf( this.patient ), typeof(Tile).GetMethod( "CardinalTurfsWithAccess" ), typeof(Tile).GetMethod( "Distance" ), 0, 30, null, null, this.botcard );

					if ( !Lang13.Bool( this.path ) ) {
						this.path = new ByTable();
					}

					if ( this.path.len == 0 ) {
						this.oldpatient = this.patient;
						this.patient = null;
						this.currently_healing = false;
						this.last_found = Game13.time;
					}
					return;
				}));
				return null;
			}

			if ( this.path.len > 0 && this.patient != null ) {
				Map13.StepTowards( this, this.path[1], 0 );
				this.path -= this.path[1];
				Task13.Schedule( 3, (Task13.Closure)(() => {
					
					if ( this.path.len != 0 ) {
						Map13.StepTowards( this, this.path[1], 0 );
						this.path -= this.path[1];
					}
					return;
				}));
			}

			if ( this.path.len > 8 && this.patient != null ) {
				this.frustration++;
			}
			return null;
		}

		// Function from file: medbot.dm
		public override void Emag( dynamic user = null ) {
			dynamic O = null;

			base.Emag( (object)(user) );

			if ( this.open && !this.locked ) {
				this.declare_crit = false;

				if ( Lang13.Bool( user ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>You short out " + this + "'s reagent synthesis circuits.</span>" );
				}
				Task13.Schedule( 0, (Task13.Closure)(() => {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
						O = _a;
						
						O.show_message( "<span class='danger'>" + this + " buzzes oddly!</span>", 1 );
					}
					return;
				}));
				Icon13.Flick( "medibot_spark", this );
				this.patient = null;

				if ( Lang13.Bool( user ) ) {
					this.oldpatient = user;
				}
				this.currently_healing = false;
				this.last_found = Game13.time;
				this.anchored = 0;
				this.emagged = 2;
				this.on = true;
				this.icon_state = "medibot" + this.on;
			}
			return;
		}

		// Function from file: medbot.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) {
				
				if ( this.allowed( b ) && !this.open && !( this.emagged != 0 ) ) {
					this.locked = !this.locked;
					GlobalFuncs.to_chat( b, "<span class='notice'>Controls are now " + ( this.locked ? "locked." : "unlocked." ) + "</span>" );
					this.updateUsrDialog();
				} else {
					
					if ( this.emagged != 0 ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>ERROR</span>" );
					}

					if ( this.open ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>Please close the access panel before locking it.</span>" );
					} else {
						GlobalFuncs.to_chat( b, "<span class='warning'>Access denied.</span>" );
					}
				}
			} else if ( a is Obj_Item_Weapon_ReagentContainers_Glass ) {
				
				if ( this.locked ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You cannot insert a beaker because the panel is locked.</span>" );
					return null;
				}

				if ( !( this.reagent_glass == null ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>There is already a beaker loaded.</span>" );
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.reagent_glass = a;
					GlobalFuncs.to_chat( b, "<span class='notice'>You insert " + a + ".</span>" );
					this.updateUsrDialog();
					return null;
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );

				if ( this.health < this.maxhealth && !( a is Obj_Item_Weapon_Screwdriver ) && Lang13.Bool( a.force ) ) {
					Map13.StepTowards( this, Map13.GetStepAway( this, b, null ), 0 );
				}
			}
			return null;
		}

		// Function from file: medbot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? adjust_num = null;
			double? adjust_num2 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["power"] ) && this.allowed( Task13.User ) ) {
				
				if ( this.on ) {
					this.turn_off();
				} else {
					this.turn_on();
				}
			} else if ( Lang13.Bool( href_list["adj_threshold"] ) && ( !this.locked || Task13.User is Mob_Living_Silicon ) ) {
				adjust_num = String13.ParseNumber( href_list["adj_threshold"] );
				this.heal_threshold += adjust_num ??0;

				if ( this.heal_threshold < 5 ) {
					this.heal_threshold = 5;
				}

				if ( this.heal_threshold > 75 ) {
					this.heal_threshold = 75;
				}
			} else if ( Lang13.Bool( href_list["adj_inject"] ) && ( !this.locked || Task13.User is Mob_Living_Silicon ) ) {
				adjust_num2 = String13.ParseNumber( href_list["adj_inject"] );
				this.injection_amount += adjust_num2 ??0;

				if ( ( this.injection_amount ??0) < 5 ) {
					this.injection_amount = 5;
				}

				if ( ( this.injection_amount ??0) > 15 ) {
					this.injection_amount = 15;
				}
			} else if ( Lang13.Bool( href_list["use_beaker"] ) && ( !this.locked || Task13.User is Mob_Living_Silicon ) ) {
				this.use_beaker = !this.use_beaker;
			} else if ( Lang13.Bool( href_list["eject"] ) && !( this.reagent_glass == null ) ) {
				
				if ( !this.locked ) {
					this.reagent_glass.loc = GlobalFuncs.get_turf( this );
					this.reagent_glass = null;
				} else {
					GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You cannot eject the beaker because the panel is locked.</span>" );
				}
			} else if ( Lang13.Bool( href_list["togglevoice"] ) && ( !this.locked || Task13.User is Mob_Living_Silicon ) ) {
				this.shut_up = !this.shut_up;
			} else if ( Lang13.Bool( href_list["declaretreatment"] ) && ( !this.locked || Task13.User is Mob_Living_Silicon ) ) {
				this.declare_treatment = !this.declare_treatment;
			} else if ( Lang13.Bool( href_list["critalerts"] ) && ( !this.locked || Task13.User is Mob_Living_Silicon ) ) {
				this.declare_crit = !this.declare_crit;
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: medbot.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			dynamic dat = null;

			_default = base.attack_hand( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}
			dat += "<TT><B>Automatic Medical Unit v1.0</B></TT><BR><BR>";
			dat += new Txt( "Status: <A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</A><BR>" ).ToString();
			dat += "Maintenance panel panel is " + ( this.open ? "opened" : "closed" ) + "<BR>";
			dat += "Beaker: ";

			if ( Lang13.Bool( this.reagent_glass ) ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";eject=1'>Loaded [" ).item( this.reagent_glass.reagents.total_volume ).str( "/" ).item( this.reagent_glass.reagents.maximum_volume ).str( "]</a>" ).ToString();
			} else {
				dat += "None Loaded";
			}
			dat += "<br>Behaviour controls are " + ( this.locked ? "locked" : "unlocked" ) + "<hr>";

			if ( !this.locked || a is Mob_Living_Silicon ) {
				dat += "<TT>Healing Threshold: ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=-10'>--</a> " ).ToString();
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=-5'>-</a> " ).ToString();
				dat += "" + this.heal_threshold + " ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=5'>+</a> " ).ToString();
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=10'>++</a>" ).ToString();
				dat += "</TT><br>";
				dat += "<TT>Injection Level: ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_inject=-5'>-</a> " ).ToString();
				dat += "" + this.injection_amount + " ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_inject=5'>+</a> " ).ToString();
				dat += "</TT><br>";
				dat += "Reagent Source: ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";use_beaker=1'>" ).item( ( this.use_beaker ? "Loaded Beaker (When available)" : "Internal Synthesizer" ) ).str( "</a><br>" ).ToString();
				dat += new Txt( "Treatment report is " ).item( ( this.declare_treatment ? "on" : "off" ) ).str( ". <a href='?src=" ).Ref( this ).str( ";declaretreatment=" ).item( 1 ).str( "'>Toggle</a><br>" ).ToString();
				dat += new Txt( "The speaker switch is " ).item( ( this.shut_up ? "off" : "on" ) ).str( ". <a href='?src=" ).Ref( this ).str( ";togglevoice=" ).item( 1 ).str( "'>Toggle</a><br>" ).ToString();
				dat += new Txt( "Critical Patient Alerts: <a href='?src=" ).Ref( this ).str( ";critalerts=1'>" ).item( ( this.declare_crit ? "Yes" : "No" ) ).str( "</a><br>" ).ToString();
			}
			Interface13.Browse( a, "<HEAD><TITLE>Medibot v1.0 controls</TITLE></HEAD>" + dat, "window=automed" );
			GlobalFuncs.onclose( a, "automed" );
			return _default;
		}

		// Function from file: medbot.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: medbot.dm
		public override void turn_off(  ) {
			base.turn_off();
			this.patient = null;
			this.oldpatient = null;
			this.oldloc = null;
			this.path = new ByTable();
			this.currently_healing = false;
			this.last_found = Game13.time;
			this.icon_state = "medibot" + this.on;
			this.updateUsrDialog();
			return;
		}

		// Function from file: medbot.dm
		public override bool turn_on(  ) {
			bool _default = false;

			_default = base.turn_on();
			this.icon_state = "medibot" + this.on;
			this.updateUsrDialog();
			return _default;
		}

	}

}