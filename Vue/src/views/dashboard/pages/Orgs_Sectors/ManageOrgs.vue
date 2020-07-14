<template>
  <v-form ref="form" lazy-validation>
    <v-row justify="center">
      <v-col cols="12" md="11">
        <v-row>
          <v-col cols="12" md="4">
            <v-select
              v-model="sector"
              :items="sectorsList"
              :rules="[v => !!v || 'نسيت اختيار القطاع']"
              item-text="value"
              item-value="id"
              label="القطاع"
              required
            ></v-select>
          </v-col>

          <v-col cols="12" md="5">
            <v-text-field
              v-model="org"
              :rules="[v => !!v || 'نسيت اختيار المؤسسة']"
              placeholder="المؤسسة"
              label="المؤسسة"
              required
              clearable
            />
          </v-col>

          <v-col cols="12" md="3" class="text-center">
            <v-card-actions>
              <v-btn color="green lighten-1" class="mr-0" @click="sendData">
                <h3>اضافة</h3>
              </v-btn>
            </v-card-actions>
          </v-col>
        </v-row>

        <v-row>
          <v-col cols="12" md="12">
            <v-data-table
              :headers="myheaders"
              :items="modifyOrgs"
              :items-per-page="5"
              class="elevation-1"
              dense
              group-by="sector"
              show-group-by
            >
              <template v-slot:item.actions="{ item }">
                <v-icon @click="deleteItemOrg(item.id)">mdi-delete</v-icon>
              </template>
            </v-data-table>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <!-- Alerts  -->
    <v-snackbar v-model="alert.status" :color="alert.color" :timeout="alert.timeout">{{ alert.txt }}</v-snackbar>
  </v-form>
</template>

<script>
import { mapActions, mapGetters, mapState } from "vuex";
import axios from "axios";
export default {
  data() {
    return {
      sectorsList: [],
      sector: null,
      org: null,
      myheaders: [
        { text: "القطاع", value: "sector" },
        { text: "المؤسسة", value: "name" },
        { text: "الاجراء", value: "actions" }
      ],
      alert: {
        status: false,
        color: null,
        txt: null,
        timeout: 2000
      }
    };
  },

  computed: {
    ...mapGetters("organization", ["GetSector"]),
    ...mapState("organization", ["organizations", "sectors"]),
    modifyOrgs() {
      return this.organizations.map(org => {
        return {
          id: org.id,
          name: org.name,
          sector: this.sectorsList.find(sec => sec.id === org.sectorID).value
        };
      });
    }
  },
  methods: {
    ...mapActions("organization", [
      "AddOrg",
      "changeSector",
      "removeOrganization"
    ]),
    sendData() {
      if (!this.org || !this.sector)
        return this.statAlert(
          true,
          "الرجاء التأكد من صحة البانات المدخلة اعلاه",
          "error"
        );
      const obiOrg = {
        id: Math.round(Math.random() * 999999),
        name: this.org,
        sectorID: this.sector
      };

      this.SaveOrg(obiOrg);
    },
    // Alert
    statAlert(status, txt, color) {
      const alert = this.alert;
      alert.status = status;
      alert.txt = txt;
      alert.color = color;
    },
    // Delete item org in table which in vuex of course
    deleteItemOrg(orgID) {
      this.removeOrganization(orgID);
    },

    SaveOrg(objOrg) {
      axios
        .post("https://localhost:44392/api/Organizations", {
          id: objOrg.id,
          name: objOrg.name,
          sectorID: objOrg.sectorID
        })
        .then(
          result => {
            this.AddOrg(objOrg);
            //alert(result.data.origin);
          },
          error => {
            console.error(error);
          }
        );
    },

    GetSectors() {
      axios
        .get("https://localhost:44392/api/Sectors")
        .then(response => (this.sectorsList = response.data));
    },

    GetOrganziations() {
      axios.get("https://localhost:44392/api/Organizations").then(response =>
        response.data.forEach(element => {
          debugger;
          this.AddOrg(element);
        })
      );
    }
  },
  mounted() {
    this.GetSectors();
    this.GetOrganziations();
  }
};
</script>
