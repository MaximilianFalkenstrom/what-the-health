import { useState } from "react";
import CalorieRing from "./CalorieRing";
import { DateInput, DatesProvider } from "@mantine/dates";
import { Box, Center } from "@mantine/core";
import MacroProgressBars from "./MacroProgressBars";
import classes from "../css/DateSelector.module.css";

export default function DateSelector() {
  const [date, setDate] = useState<Date>(new Date(Date.now()));

  return (
    <Box key={date.toString()}>
      <CalorieRing date={date} />
      <DatesProvider settings={{ timezone: "UTC" }}>
        <Center mt={"xs"}>
          <DateInput
            classNames={{
              input: classes.date,
            }}
            variant="filled"
            size="sm"
            valueFormat="YYYY-MM-DD"
            radius={"xl"}
            value={date}
            onChange={(value) => {
              if (value) {
                setDate(value);
              }
            }}
          />
        </Center>
      </DatesProvider>
      <MacroProgressBars date={date} />
    </Box>
  );
}
