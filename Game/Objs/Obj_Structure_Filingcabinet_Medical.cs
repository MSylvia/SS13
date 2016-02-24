// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Filingcabinet_Medical : Obj_Structure_Filingcabinet {

		public bool virgin = true;

		public Obj_Structure_Filingcabinet_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: filingcabinet.dm
		public override void attack_tk( Mob_Living_Carbon_Human user = null ) {
			this.populate();
			base.attack_tk( user );
			return;
		}

		// Function from file: filingcabinet.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.populate();
			base.attack_hand( (object)(a), b, c );
			return null;
		}

		// Function from file: filingcabinet.dm
		public void populate(  ) {
			Data_Record G = null;
			Data_Record M = null;
			Obj_Item_Weapon_Paper P = null;
			int counter = 0;

			
			if ( this.virgin ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.data_core.general, typeof(Data_Record) )) {
					G = _a;
					
					M = GlobalFuncs.find_record( "name", G.fields["name"], GlobalVars.data_core.medical );

					if ( !( M != null ) ) {
						continue;
					}
					P = new Obj_Item_Weapon_Paper( this );
					P.info = "<CENTER><B>Medical Record</B></CENTER><BR>";
					P.info += "Name: " + G.fields["name"] + " ID: " + G.fields["id"] + "<BR>\nSex: " + G.fields["sex"] + "<BR>\nAge: " + G.fields["age"] + "<BR>\nFingerprint: " + G.fields["fingerprint"] + "<BR>\nPhysical Status: " + G.fields["p_stat"] + "<BR>\nMental Status: " + G.fields["m_stat"] + "<BR>";
					P.info += "<BR>\n<CENTER><B>Medical Data</B></CENTER><BR>\nBlood Type: " + M.fields["blood_type"] + "<BR>\nDNA: " + M.fields["b_dna"] + "<BR>\n<BR>\nMinor Disabilities: " + M.fields["mi_dis"] + "<BR>\nDetails: " + M.fields["mi_dis_d"] + "<BR>\n<BR>\nMajor Disabilities: " + M.fields["ma_dis"] + "<BR>\nDetails: " + M.fields["ma_dis_d"] + "<BR>\n<BR>\nAllergies: " + M.fields["alg"] + "<BR>\nDetails: " + M.fields["alg_d"] + "<BR>\n<BR>\nCurrent Diseases: " + M.fields["cdi"] + " (per disease info placed in log/comment section)<BR>\nDetails: " + M.fields["cdi_d"] + "<BR>\n<BR>\nImportant Notes:<BR>\n	" + M.fields["notes"] + "<BR>\n<BR>\n<CENTER><B>Comments/Log</B></CENTER><BR>";
					counter = 1;

					while (Lang13.Bool( M.fields["com_" + counter] )) {
						P.info += "" + M.fields["com_" + counter] + "<BR>";
						counter++;
					}
					P.info += "</TT>";
					P.name = "paper - '" + G.fields["name"] + "'";
					this.virgin = false;
				}
			}
			return;
		}

	}

}