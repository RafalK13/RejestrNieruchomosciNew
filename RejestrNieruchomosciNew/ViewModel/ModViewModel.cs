using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class ModViewModel : ChangeViewModel
    {
        #region ICommand
        //public ICommand OnCloseWindow { get; set; }
        //public ICommand OnAddDzialka { get; set; }
        #endregion

        public string tytulNr { get; set; }
        public string tytulObr { get; set; }
        public string tytulGm { get; set; }

        public PerformMode mode { get; set; }

        public static object CloneObject1(object obj)
        {
            using (var memStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(memStream, obj);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                memStream.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(memStream);
            }
        }

        public static T Clone<T>(T obj) where T : class
        {
            var serializer = new DataContractSerializer(typeof(T), null, int.MaxValue, false, true, null);
            using (var ms = new System.IO.MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                ms.Position = 0;
                return (T)serializer.ReadObject(ms);
            }
        }

        public static object CloneObject(object obj)
        {
            using (var memStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter(
                     null,
                     new StreamingContext(StreamingContextStates.Clone));
                binaryFormatter.Serialize(memStream, obj);
                memStream.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(memStream);
            }
        }

        //public DzialkaValidator _validatorDzialka { get; set; }



        public ModViewModel(UserControl_DanePodstawoweViewModel userPodst,
                        UserControl_DaneDodatkoweViewModel userDod,
                        UserControl_PreviewViewModel userPrev1,
                        IDzialka dzialkaSel,
                        DzialkaValidator _validatorDzialka)
        {
            tabsVisible = true;

            #region testSoluti
            //dzialkaSel = userPrev1.dzialkaSel;          
            //dzialkaSel = (Dzialka)CloneObject1(userPrev1.dzialkaSel);
            #endregion

            #region Old solution
            //dzialkaSel.copy(userPrev1.dzialkaSel);

            //userPodst.dzialka.copy(dzialkaSel);
            //userPodst.obreb.fillValues(dzialkaSel);


            //dzialkaSel = userPrev1.dzialkaSel;

            //userPodst.dzialka= dzialkaSel;
            //userPodst.obreb.fillValues(dzialkaSel); 

            #endregion

            #region New Solution
            dzialkaSel = userPrev1.dzialkaSel;
            userPodst.dzialka = StaticFunctions.Clone1(dzialkaSel);
            userPodst.obreb.fillValues(dzialkaSel);
            userDod.dzialka = dzialkaSel;

            userPodst.dzialka._validatorDzialka = _validatorDzialka;

            userControl_AddDanePod = userPodst;
            userControl_AddDanePod.changeMode = ChangeMode.mod;

            userControl_DaneDod = userDod;
            #endregion
        }

        public override void onAddDzialka()
        {
            MessageBox.Show("Mod");
            //userControl_prevModel.dzialkiBase.ModRow( userControl_AddDanePod.dzialka);
            //userControl_prevModel.dzialkaView.Refresh();
        }

        public override void onCloseWindow()
        {
            mode.appMod = PerformMode.appMode.main;
        }
    }
}
