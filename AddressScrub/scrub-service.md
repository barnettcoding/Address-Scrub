# Scrub & Skip Service

## Input File

```
{
  "id": <string, required, file unique id>,
  "title": <string, user freindly name>,
  "options": {
    "removeDuplicates": <bool, remove duplicates from list, default:false>,
    "removeMinors":<bool, remove anyone with an age under 18, default:false>,
    "removeSeniors": <bool, remove anyone 65+, default:false>,
    "removeDeceased": <bool, remove anyone who has died, default:false>,
    "checkForInsurance": <bool, checks for insurance if provider field is blank, default:false>,
    "skipTrace": <bool, default:false>,
    "address": {
      "validate": <bool, required (conditional), perform address validation, default:false>,
      "blankIfInvalid": <bool, required (conditional), default:false>,
      "ncoa": <bool, required (conditional), perform NOCA scrub, default:false>,
    },
    "email": {
      "validate": <bool, perform email validation, default:false>,
      "blankIfInvalid": <bool, required (conditional), default:false>
    },
    "phone": {
      "validate": <bool, perform phone validation, default:false>,
      "blankIfInvalid": <bool, required (conditional), default:false>
    },
  },
  "data": [{
    "record": <string, required, uniqueidentifier for record>,
    "name": {
      "firstName": <string, required>,
      "lastName": <string, required>,
    },
   "dob": <date, required (conditional), date of birth>,
   "ssn": <string, social security number>,
    "address": {
      "line1": <string, required (conditional), primary street information>
      "line2": <string, secondary street information (apartment, suite, ect)>
      "city": <string, required (conditional), city of address>
      "state": <string, required (conditional), state/province of address>
      "postalCode": <string, required (conditional), postal code of address>
    },
    "email": <string, email address>,
    "phone": <string, phone number>
  },
  { ... }]
}
```

---

### Input File Definitions

id (string, required)
: A unique identifier for referencing results as they transfered back to the requesting service.

title (string, not required)
: A user friendly name for the scrub. No impact on processes.

options (object, required)
: An object containing the potential scrub options. By default, all options are set to false. If no options are selected, the uploaded data set will be returned without any modification

- removeDuplicates
- removeMinors
- removeSeniors
- removeDeceased
- checkForInsurance
- skipTrace
- address
- - validate
- - ncoa
- - blankIfInvalid
- email
- - validate
- - blankIfInvalid
- phone
- - validate
- - blankIfInvalid

data (object, required)
: An object containing the data required to run the different scrub processes. If this object is empty return object with an error.

- record (string, required): uniqueidentifier for the specific record.
- name (object, required): name of the person in the record.
- dob (date, required): date of birth
- ssn (string, optional): ssn for the record
- address (object, optional)
- email (string, optional)
- phone (string, optional)

---

### Methodology

1. Remove duplicates
2. Remove minors (anyone under 18 years old)
3. Remove seniors (anyone 65 or older)
4. Remove deceased
8. SSN
   8a. Blank if SSN is all 0's or 9's
5. Address
   5a. Validate address
   5b. Run address through ncoa
   5c. Blank addresss if not valid, no ncoa return
6. Phone
   6a. Clear phones that are all the same digit
   6b. Validate phone
   6c. Blank phone if invalid.
7. Email
   7a. Clear emails that don't have basic valid structure
   7b. Validate email
   7c. Blank email if invalid

9. Insurance
   9a. Check with free state services if they qualify for medicare/medicaid
   9b. Check with Pronto to see if they have insurance,
10. Skip
    10a. Run skip for missing communication methods.
    10b. Remove those without a valid communication method after skipping.

---

## Output File

```
{
    "id": <string, file unique id>,
    "title": <string, user freindly name>,
    "submittedOn": <date, date file was submitted on>,
    "processingCompleted": <date, date file processing completed>,
    "data": [{
      "record": <string, required, uniqueidentifier for record>,
      "name": {
        "firstName": <string, required>,
        "lastName": <string, required>,
      },
      "dob": <date, required (conditional), date of birth>,
      "ssn": <string, social security number>,
      "address": {
        "originalValue": {
          "line1": <string, required (conditional), primary street information>
          "line2": <string, secondary street information (apartment, suite, ect)>
          "city": <string, required (conditional), city of address>
          "state": <string, required (conditional), state/province of address>
          "postalCode": <string, required (conditional), postal code of address>
        }
      },
      "email": {
        "originalValue": <string, original value>
        "scrubbedValue": <string, scrubbed value>
        "scrubbed": <bool, was original value srubbed, default:false>
      },
      "phone": {
        "originalValue": <string, original value>
        "scrubbedValue": <string, scrubbed value>
        "scrubbed": <bool, was original value srubbed, default:false>
      },
      scrubStatus: {
          isDuplicate: <bool?, default:null>,
          isMinor: <bool?, default:null>,
          isSenior: <bool?, default:null>,
          isDead: <bool?, default:null>,
          hasValidAddress: <bool?, default:null>,
          passedNcoa: <bool?, default:null>,
          hasValidPhone: <bool?, default:null>,
          hasValidEmail: <bool?, default:null>,
          hasInsurance: <bool?, default:null>,
          isSkipped: <bool?, default:null>,
      }
  },
  { ... }]
}
```
