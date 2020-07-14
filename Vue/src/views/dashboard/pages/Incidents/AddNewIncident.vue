<template>
  <v-container id="user-5" fluid tag="section">
    <v-row justify="center">
      <v-col cols="12" md="11">
        <base-material-card title="تسجيل حادثة جديدة">
          <div>
            <v-form>
              <v-container class="py-0">
                <v-row>
                  <v-col cols="12" md="6">
                    <v-text-field v-model="Incident.Subject" label="عنوان الحادث" />
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12" md="3">
                    <v-select
                      v-model="sectorSelected"
                      :items="sectorsList"
                      item-text="value"
                      item-value="id"
                      @change="changeSector"
                      label="القطاع"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" md="3">
                    <v-select
                      item-text="name"
                      v-model="orgSelected"
                      :items="orgs"
                      item-value="id"
                      label="الجهة المتأثرة"
                    ></v-select>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-menu
                      v-model="menu2"
                      :close-on-content-click="false"
                      :nudge-right="40"
                      transition="scale-transition"
                      offset-y
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="Incident.Date"
                          label="تاريخ الحادثة"
                          readonly
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker v-model="Incident.Date" @input="menu2 = false"></v-date-picker>
                    </v-menu>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-menu
                      ref="menu"
                      v-model="time2"
                      :close-on-content-click="false"
                      :nudge-right="40"
                      :return-value.sync="time"
                      transition="scale-transition"
                      offset-y
                      max-width="290px"
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field v-model="Incident.Time" label="وقت الحادث" readonly v-on="on"></v-text-field>
                      </template>
                      <v-time-picker
                        v-if="time2"
                        v-model="Incident.Time"
                        full-width
                        @click:minute="$refs.menu.save(time)"
                      ></v-time-picker>
                    </v-menu>
                  </v-col>
                </v-row>
                <v-row justify="center">
                  <v-col cols="12" md="3">
                    <v-select
                      return-object
                      v-model="Incident.Cat"
                      :items="incidents.Cat"
                      item-text="label"
                      item-value="code"
                      label="فئة الحادثة"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" md="3">
                    <v-select
                      return-object
                      v-model="Incident.Sver"
                      :items="incidents.Sver"
                      item-text="label"
                      item-value="code"
                      label="مستوى الخطورة"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" md="3">
                    <v-select
                      return-object
                      v-model="Incident.Urgancey"
                      :items="incidents.Urgancey"
                      item-text="label"
                      item-value="code"
                      label="الأهمية"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" md="3">
                    <v-select
                      return-object
                      v-model="Incident.Status"
                      :items="incidents.Status"
                      item-text="label"
                      item-value="code"
                      label="الحالة"
                    ></v-select>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12" md="12">
                    <v-textarea rows="5" v-model="Incident.Description" label="تفاصيل الحادث" />
                  </v-col>
                </v-row>
                <!-- Attachments -->
                <v-row>
                  <v-col cols="12" md="12">
                    <v-file-input
                      v-model="fileAttach"
                      accept=".pdf"
                      multiple
                      chips
                      label="File Attachments"
                    ></v-file-input>
                  </v-col>
                </v-row>
                <!-- IP & Ports -->
                <v-row>
                  <v-col cols="12" md="6">
                    <v-row v-for="(ip, index) in Incident.ipAddresses" :key="ip.id">
                      <!-- actions -->
                      <v-col cols="1" md="1">
                        <a
                          v-if="Incident.ipAddresses.length === index + 1"
                          href="javascript:void(0)"
                          class="sc-color-primary"
                          @click="addIp($event)"
                        >
                          <i class="mdi mdi-plus sc-icon-24"></i>
                        </a>
                        <a
                          v-if="Incident.ipAddresses.length !== index + 1"
                          href="javascript:void(0)"
                          class="sc-color-primary"
                          @click="removeIp($event, ip)"
                        >
                          <i class="mdi mdi-minus sc-icon-24"></i>
                        </a>
                      </v-col>
                      <!-- IP Address -->
                      <v-col cols="12" md="6" class="text-center">
                        <div class="mb-2">عنوان الانترنت المصدر</div>
                        <vue-ip
                          class="ipInput"
                          :ip="ip.ip"
                          :on-change="checkSourceStatusIP"
                          theme="material"
                        ></vue-ip>
                      </v-col>
                      <!-- Port -->
                      <v-col cols="12" md="5">
                        <v-text-field v-model="ip.port.source" type="number" label="Port Source"></v-text-field>
                      </v-col>
                    </v-row>
                  </v-col>
                  <v-col cols="12" md="6">
                    <v-row v-for="(ip, index) in Incident.ipAddresses" :key="ip.id">
                      <v-col cols="1" md="1">
                        <a
                          v-if="Incident.ipAddresses.length === index + 1"
                          href="javascript:void(0)"
                          class="sc-color-primary"
                          @click="addIp($event)"
                        >
                          <i class="mdi mdi-plus sc-icon-24"></i>
                        </a>
                        <a
                          v-if="Incident.ipAddresses.length !== index + 1"
                          href="javascript:void(0)"
                          class="sc-color-primary"
                          @click="removeIp($event, ip)"
                        >
                          <i class="mdi mdi-minus sc-icon-24"></i>
                        </a>
                      </v-col>
                      <!-- IP Address -->
                      <v-col cols="12" md="6" class="text-center">
                        <div class="mb-2">عنوان الانترنت المستهدف</div>
                        <vue-ip
                          class="ipInput"
                          :ip="ip.ip"
                          :on-change="checkDestinationStatusIP"
                          theme="material"
                        ></vue-ip>
                      </v-col>
                      <!-- Port -->
                      <v-col cols="12" md="5">
                        <v-text-field type="number" label="Port Destination" v-model="ip.port.dest"></v-text-field>
                      </v-col>
                    </v-row>
                  </v-col>
                </v-row>
                <!-- Actions -->
                <v-row justify="center">
                  <v-col cols="12" md="3">
                    <v-btn color="success" class="mr-0" @click="add">حفظ</v-btn>
                  </v-col>
                  <v-col cols="12" md="3">
                    <v-btn color="error" class="mr-0" @click="close">إغلاق</v-btn>
                  </v-col>
                </v-row>
              </v-container>
            </v-form>
          </div>
        </base-material-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import stringHelper from "../../../../helpers/stringHelper";
import { mapGetters, mapActions, mapMutations, mapState } from "vuex";
import VueIp from "vue-ip";
import axios from "axios";
export default {
  components: { VueIp },
  data() {
    return {
      fileAttach: [],
      sectorsList: [],
      time2: false,
      menu2: false,
      date: new Date().toISOString().substr(0, 10),
      time: null,
      ipLabel: "IP address",
      Incident: {
        id: stringHelper.uniqueID(),
        Status: "",
        Subject: "",
        Date: "",
        Time: "",
        Cat: "",
        Description: "",
        Sector: "",
        Org: "",
        Urgancey: "",
        Sver: "",
        SourceIpAddress: "",
        SourceIpPort: "",
        DestinationIpAddress: "",
        DescriptionIpPort: "",
        ipAddresses: [
          {
            id: stringHelper.uniqueID(),
            ip: "",
            port: { source: "", dest: "" }
          }
        ]
      },
      sectorSelected: null,
      orgSelected: null,
      orgs: []
    };
  },
  computed: {
    ...mapState(["incidents"]),
    ...mapState("organization", ["sectors", "organizations"])
    // ...mapState({
    // 	sector: state => state.Incidents.sector,
    // }),
    // ...mapState({
    // 	sector: state => state.incidents.sector,
    // }),
    // ...mapState("Incidents",['Incidents','getCat','getSector','getUrgancy','getOrg','getSver',''])
  },
  methods: {
    ...mapActions("incidents", ["addIncident"]),
    ...mapMutations("incidents", ["newIncidnt"]),
    changeSector() {
      this.GetOrganizationsBySectorId(this.sectorSelected);

      // this.orgs = this.organizations.filter(org => {
      //   return org.sectorID == this.sectorSelected;
      // });
    },
    add() {
      this.AddIncident();
      // this.addIncident(this.Incident);
      // this.$router.push("DisplayIncidents");
    },
    close() {
      this.$router.push("DisplayIncidents");
    },
    addIp(e) {
      e.preventDefault();
      this.Incident.ipAddresses.push({
        id: this.uniqueID(),
        ip: "",
        port: { source: "", dest: "" }
      });
    },
    removeIp(e, ip) {
      e.preventDefault();
      this.Incident.ipAddresses = this.Incident.ipAddresses.filter(oldIp => {
        if (ip == oldIp) return false;
        return true;
      });
    },
    uniqueID(length) {
      let id = "";
      const possible =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-";
      const _length = length || 8;
      for (let i = 0; i < _length; i++) {
        id += possible.charAt(Math.floor(Math.random() * possible.length));
      }
      return id;
    },
    checkSourceStatusIP(ip, valid) {
      this.Incident.SourceIpAddress = ip;
    },
    checkDestinationStatusIP(ip, valid) {
      this.Incident.DestinationIpAddress = ip;
    },
    GetSectors() {
      axios
        .get("https://localhost:44392/api/Sectors")
        .then(response => (this.sectorsList = response.data));
    },

    GetOrganizationsBySectorId(sectorId) {
      debugger;
      axios
        .get(
          "https://localhost:44392/api/Organizations/" + sectorId + "/BySector"
        )
        .then(response => (this.orgs = response.data));
    },

    AddIncident() {
      var date = {
        Subject: this.Incident.Subject,
        Description: this.Incident.Description,
        Date: this.Incident.Date,
        //Time: this.Incident.Time,
        Urgancey: parseInt(this.Incident.Urgancey.code),
        Status: parseInt(this.Incident.Status.code),
        Category: parseInt(this.Incident.Cat.code),
        Sverity: parseInt(this.Incident.Sver.code),
        OrganizationId: this.orgSelected,
        SourceIpAddress: this.Incident.SourceIpAddress + ":" + this.Incident.ipAddresses[0].port.source,
        DestinationIpAddress: this.Incident.DestinationIpAddress + ":" + this.Incident.ipAddresses[0].port.dest,
        File: this.fileAttach[0]
      };

      axios.post("https://localhost:44392/api/Incidents", date).then(
        result => {
          this.addIncident(this.Incident);
          this.$router.push("DisplayIncidents");
        },
        error => {
        }
      );
    }
  },
  created() {
    this.Incident = {
      id: stringHelper.uniqueID(),
      Status: "",
      Subject: "",
      Date: "",
      Time: "",
      Cat: "",
      Description: "",
      Sector: "",
      Org: "",
      Urgancey: "",
      Sver: "",
      ipAddresses: [
        { id: stringHelper.uniqueID(), ip: "", port: { source: "", dest: "" } }
      ]
    };
  },
  mounted() {
    this.GetSectors();
  }
};
</script>
<style lang="scss">
.ipInput {
  direction: ltr;
  border: 1px solid black !important;
  input {
    width: 100%;
    color: black !important;
    &:after {
      color: black !important;
    }
  }
}
</style>