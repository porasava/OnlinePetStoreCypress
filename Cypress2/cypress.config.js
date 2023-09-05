const { defineConfig } = require('cypress')

module.exports = defineConfig({
   videoCompression: false,
    projectId: "c2z66j",
    reporter: 'cypress-mochawesome-reporter',
    reporterOptions: {
      charts: true,
      reportPageTitle: 'custom-title',
      embeddedScreenshots: true,
      inlineAssets: true,
      "html": true,
      saveAllAttempts: false,
      screenshotOnRunFailure:true,
      reportDir: "cypress/reports/mocha",
    },
    screenshotsFolder: "cypress/reports/mochareports/screenshots",
    //videoCompression: false,
    experimentalStudio: true,
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
      require('cypress-mochawesome-reporter/plugin')(on);
    },

   // specPattern:'test/*.js',
    /*     screenshotsFolder:'cypress/failures/screenshots' */
    setupNodeEvents(on, config) {
      require('cypress-mochawesome-reporter/plugin')(on);
    }},
    /* experimentalStudio: true */
    });
