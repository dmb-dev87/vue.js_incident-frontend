export default {
    // communicate directly with the state variables
    newSignature: (state, signature) => state.apt.threatSignatures.push( signature ),
    AddAlterName(state, alterName) {

        let names = state.apt.alternativeNames;
        let max = Math.max(names.map(name => name.Id).push(0));
        alterName.Id = max + 1;
        state.apt.alternativeNames.push(alterName);

    },
    newGroup: (state, group) => state.apt.name = group,
    AddCountryToApt: (state, country) => state.apt.originCountry.push(country),
    TargetCountry: (state, targeted) => state.apt.targetedCountries.push(targeted),
    // newContent : (state, content) => state.apt.content = content,
    removeCountry: (state, id) => state.apt.originCountry = state.apt.originCountry.filter(con => con.Id != id),
    removTargeted: (state, id) => state.apt.targetedCountries = state.apt.targetedCountries.filter(con => con.Id != id),
    removeAlternativeName: (state, id) => state.apt.alternativeNames = state.apt.alternativeNames.filter(con => con.Id != id),
    setContent: (state, payload) => state.apt.contents.push(payload),
    setFiles: (state, files) => state.apt.attachments = files,
    allApts: (state, apts) => state.apts = apts,
    selectedApt: (state, apt) => state.selectedApt = apt,
    searchKey: (state, key) => state.searchKey = key,
    setEditApt: (state, apt) => { state.apt = apt; state.editedApt = apt },


}