using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whackerlink_CPS
{
    public partial class Systems : Form
    {
        public Systems()
        {
            InitializeComponent();
        }
        public void SetRadioWideData(Codeplug.RadioWideConfiguration radioWide)
        {
            txtHostVersion.Text = radioWide.hostVersion;
            txtCodeplugVersion.Text = radioWide.codeplugVersion;
            txtRadioAlias.Text = radioWide.radioAlias;
            txtSerialNumber.Text = radioWide.serialNumber;
            txtModel.Text = radioWide.model.ToString();
        }

        public void SetSystemData(Codeplug.System selectedSystem)
        {
            
        }
    }
}