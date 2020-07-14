export default {
  incidentsTable: (state)=>{
    // return state.Incidents;
    return state.Incidents.map(obj => {
      return  {
        id: obj.id,
        Subject: obj.Subject,
        Sver: obj.Sver.label,
        Org: obj.Org.label,
        Status: obj.Status.label,
        Cat: obj.Cat.label,
        Description: "",
        Sector: obj.Sector.label,
        Urgancey: obj.Urgancey.label,
      }
      }
    );
  },
  incidentById: (state) => (id) => {
    return state.Incidents.find(obj => obj.id === id);
  },
  incidentsTableHeader:(state) => state.Headers,
  getCat:(state) => state.Cat,
  getSector : (state) => state.sector,
  getOrg : (state) => state.org,
  getUrgancy : (state) => state.Urgancy,
  getSver : (state) => state.Sver,
  comments: state => index => {
    return state.comments.filter(el => el.postID === index);
  }
}
