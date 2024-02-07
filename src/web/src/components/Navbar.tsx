import { AppShell, Burger, Group, UnstyledButton } from '@mantine/core';
import { useDisclosure } from '@mantine/hooks';
import classes from './css/Navbar.module.css';
import { ReactNode } from 'react';
import { Link } from 'react-router-dom';
import ColorSchemeToggle from './ColorSchemeToggle';

type NavbarProps = {
    isAuthenticated: boolean,
    children: ReactNode
}

export default function Navbar(props: NavbarProps) {
    const [opened, { toggle }] = useDisclosure();

    if (!props.isAuthenticated) {
        return props.children;
    }

    return (
        <AppShell
            header={{ height: 60 }}
            navbar={{ width: 300, breakpoint: 'sm', collapsed: { desktop: true, mobile: !opened } }}
            padding="md"
        >
            <AppShell.Header>
                <Group h="100%" px="md">
                    <Burger opened={opened} onClick={toggle} hiddenFrom="sm" size="sm" />
                    <Group justify="space-between" style={{ flex: 1 }}>
                        <Group>
                            <UnstyledButton size="xl" fw={600} component={Link} to="/">WhatTheHealth</UnstyledButton>
                            <Group ml="xl" gap="xl" visibleFrom="sm">
                                <UnstyledButton className={classes.control} component={Link} to="/">Home</UnstyledButton>
                            </Group>
                        </Group>
                        <ColorSchemeToggle />
                    </Group>
                </Group>
            </AppShell.Header>

            <AppShell.Navbar py="md" px={4}>
                <UnstyledButton className={classes.control} component={Link} to="/">Home</UnstyledButton>
            </AppShell.Navbar>

            <AppShell.Main>
                {props.children}
            </AppShell.Main>
        </AppShell>
    );
}