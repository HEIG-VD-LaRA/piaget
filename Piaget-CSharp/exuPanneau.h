
typedef
   enum tPh {Pret, EnMatch, GameOver}  tPhase;
   tPhase PhaseMatch;
   typedef
  typedef struct
   tPalet  {
  //    int ligne,colonne; //(*position d'affichage *)
      AnsiString nom;
      TColor CouleurAPrendre; //  tCouleur Couleur;
      TColor CouleurPris; //  tCouleur Couleur;
      tSLPoint position;
    //  ForeColor:integer;
      bool APrendre;
  //    char caractere;
      }   tPalet ;
  // float const pi=3.1416;
  int NPalets=12;
  int NBallesPrises=0;
  bool PresenceBalleEntree;
  bool ReflexEntreeDemande;
  bool GestionBalleEnCours;
  bool V8TimeOut;
  bool DetectionBalise;
  int uTGestionEntreeNCycles;
  float uTGestionEntreeDureeMax;
  int SecondesPasseesRel;
  int mStrategie;                                             
  bool TirBoule=false,TirBouleAdv=false, TirBalles=false;
  int DistanceUSHaut = 20;

  tPalet Palet[14];             //  tPalet Palet[12]; julien
 

 #endif


